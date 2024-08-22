using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UHFReader288Demo
{
    public class NamedPipeServer
    {
        private List<dataEPC> _dataList = new List<dataEPC>();
        private string _message;
        private readonly object _dataLock = new object();
        private readonly object _dataListLock = new object();
        private bool _running = true; // Control flag for server loop

        public NamedPipeServer()
        {
            Task.Run(() => StartServer());
        }

        public void AddData(dataEPC data)
        {
           
                _dataList.Add(data);
            
        }


        public void ClearAllData()
        {
           
                _dataList.Clear();
             
           
        }

        public void SetMessage(string message)
        {

                _message = message;
            
        }

        private void StartServer()
        {
            while (_running)
            {
                try
                {
                    using (var server = new NamedPipeServerStream("StringPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous))
                    {
                        
                        server.WaitForConnection();
                  

                        using (var reader = new StreamReader(server))
                        using (var writer = new StreamWriter(server) { AutoFlush = true })
                        {
                            while (_running)
                            {
                                try
                                {
                                    var request = reader.ReadLine();
                                    if (request == null)
                                    {
                                       
                                        break;
                                    }

                                    if (request == "GET_STRINGS")
                                    {
                                        lock (_dataLock)
                                        {
                                            var jsonData = JsonConvert.SerializeObject(_dataList);
                                            writer.WriteLine(jsonData);
                                        }
                                    }
                                  
                                    else if (request == "GET_MESSAGE")
                                    {
                                        lock (_dataLock)
                                        {
                                            writer.WriteLine(_message);
                                            _message = null;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Unhandled request: {request}");
                                        break;
                                    }
                                }
                                catch (IOException ioEx)
                                {
                                    Console.WriteLine($"IO Exception: {ioEx.Message}");
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"IO Exception in server loop: {ioEx.Message}");
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception in server loop: {ex.Message}");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        public void StopServer()
        {
            _running = false;
        }
    }

}
