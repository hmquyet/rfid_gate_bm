
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Sockets;


namespace apiApp.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class RfidController : ControllerBase
    {
        private readonly IHubContext<ScanHub> _hubContext;

        private readonly NamedPipeClient _pipeClient = new NamedPipeClient();
        public RfidController(IHubContext<ScanHub> hubContext, IMemoryCache memoryCache, IHttpClientFactory httpClientFactory)
        {
            _hubContext = hubContext;
        }
        [HttpGet("start")]
        public async Task<IActionResult> StartScan()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "StartScan");
            return Ok(new { message = "Success" });

        }
        [HttpGet("stop")]
        public async Task<IActionResult> StopScan()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "StopScan");
            return Ok(new { message = "Success" });

        }

        [HttpGet("lamp")]
        public async Task<IActionResult> Lamp([FromQuery] string mode,[FromQuery] string lampId, [FromQuery] string time)
        {
            if (string.IsNullOrEmpty(mode) || (mode != "simple" && mode != "blink"))
            {
                return BadRequest("mode must be simple or blink");
            }
            if (string.IsNullOrEmpty(lampId) || (lampId != "red" && lampId != "green")) 
            {
                return BadRequest("LampId must be red or green");
            }
            if (float.Parse(time) <= 0)
            {
                return BadRequest("time must > 0");
            }
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"Lamp:{mode}:{lampId}:{time}");
            return Ok(new { message = "Success" });
        }
        [HttpGet("buzzer")]
        public async Task<IActionResult> Buzzer([FromQuery] string time)
        {

            if (float.Parse(time) <= 0)
            {
                return BadRequest("time must > 0.");
            }
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"Buzzer:{time}");
            return Ok(new { message = "Success" });
        }
        [HttpGet("selectMode")]
        public async Task<IActionResult> Mode([FromQuery] string selectMode)
        {
            if (string.IsNullOrEmpty(selectMode) || (selectMode != "auto" && selectMode != "manual"))
            {
                return BadRequest("Mode must be 'auto' or 'manual'.");
            }

            int mode = selectMode == "auto" ? 1 : 0;

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"Mode:{mode}");
            return Ok(new { message = "Success" });
        }
        [HttpGet("removeData")]
        public async Task<IActionResult> RemoveData([FromQuery] string epc)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"RemoveData:{epc}");

            try
            {
                await Task.Delay(500);
                string message = await _pipeClient.GetMessageAsync();
                var data = await _pipeClient.GetStringListAsync();

                if(message == "notexist")
                {
                    return BadRequest("data does not exist");
                }
                else
                {
                    return Ok(data);
                }
                    
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }

        [HttpGet("removeAllData")]
        public async Task<IActionResult> ClearAllData()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "ClearAllData");
            return Ok(new { message = "Success" });

        }

        [HttpGet("request")]
        public async Task<ActionResult<List<dataEPC>>> Get()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Request");
            try
            {
                await Task.Delay(500);
                var data = await _pipeClient.GetStringListAsync();

                if (data == null || data.Count == 0)
                {
                    //return StatusCode(500, "Internal server error: No data returned from Named Pipe");
                    return Ok(new List<dataEPC>());
                }

                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
