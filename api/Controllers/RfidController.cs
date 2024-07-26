using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;


namespace api.Controllers
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

        [HttpPost("start")]
        public async Task<IActionResult> StartScan()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "StartScan");
            return Ok(new { message = "Success" });

        }
        [HttpPost("stop")]
        public async Task<IActionResult> StopScan()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "StopScan");
            return Ok(new { message = "Success" });

        }
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshData()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Refresh");
            return Ok(new { message = "Success" });

        }
        [HttpGet("request")]
        public async Task<ActionResult<List<dataEPC>>> Get()
        {
           
            try
            {
                var data = await _pipeClient.GetStringListAsync();

                if (data == null || data.Count == 0)
                {
                    return StatusCode(500, "Internal server error: No data returned from Named Pipe");
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
