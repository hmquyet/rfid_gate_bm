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

        public NamedPipeServer()
        {
            Task.Run(() => StartServer());
        }

        public void AddData(dataEPC data)
        {
            _dataList.Add(data);
        }
        public void ClearData()
        {
            _dataList.Clear();
        }
        private readonly object _dataListLock = new object();
        private void StartServer()
        {
            //while (true)
            //{
            //    using (var server = new NamedPipeServerStream("StringPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous))
            //    {
            //        server.WaitForConnection();
            //        using (var reader = new StreamReader(server))
            //        using (var writer = new StreamWriter(server) { AutoFlush = true })
            //        {
            //            while (true)
            //            {
            //                var request = reader.ReadLine();
            //                if (request == "GET_STRINGS")
            //                {
            //                    // Chuyển danh sách thành JSON và gửi đi
            //                    var jsonData = JsonConvert.SerializeObject(_dataList);
            //                    writer.WriteLine(jsonData);
            //                }
            //                else
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}

            while (true)
            {
                try
                {
                    using (var server = new NamedPipeServerStream("StringPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous))
                    {
                        server.WaitForConnection();
                        using (var reader = new StreamReader(server))
                        using (var writer = new StreamWriter(server) { AutoFlush = true })
                        {
                            while (true)
                            {
                                var request = reader.ReadLine();
                                if (request == "GET_STRINGS")
                                {
                                    lock (_dataListLock)
                                    {
                                        var jsonData = JsonConvert.SerializeObject(_dataList);
                                        writer.WriteLine(jsonData);
                                    }
                                }
                                else
                                {
                                    // Handle other requests or exit the loop
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception and continue
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }
    }
}
