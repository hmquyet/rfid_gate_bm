using Newtonsoft.Json;
using System.IO.Pipes;

namespace api
{
    public class NamedPipeClient 
    {
        public async Task<List<dataEPC>> GetStringListAsync()
        {
            try
            {
                using (var client = new NamedPipeClientStream(".", "StringPipe", PipeDirection.InOut, PipeOptions.Asynchronous))
                {
                    await client.ConnectAsync();
                    using (var reader = new StreamReader(client))
                    using (var writer = new StreamWriter(client) { AutoFlush = true })
                    {
                        writer.WriteLine("GET_STRINGS");
                        var response = await reader.ReadLineAsync();
                        // Giải tuần tự JSON thành danh sách các đối tượng dataEPC
                        var dataList = JsonConvert.DeserializeObject<List<dataEPC>>(response);
                        return dataList;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
