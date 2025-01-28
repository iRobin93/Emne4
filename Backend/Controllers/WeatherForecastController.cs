using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext appDbContext;
        public WeatherForecastController(AppDbContext appDbContext, ILogger<WeatherForecastController> logger)
        {
            this.appDbContext = appDbContext;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return appDbContext.forecast.ToList();

        }


        [HttpPost(Name = "PostWeatherForecast")]
        public IActionResult Post(WeatherForecast forecast)
        {
         

            appDbContext.Add(forecast);
            appDbContext.SaveChanges();

            return Ok();
        }


        [HttpPut(Name = "PutWeatherForecast")]
        public async Task<IActionResult> Put(WeatherForecast forecast)
        {


            var existingProduct = await appDbContext.forecast.FindAsync(forecast.Date);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Summary = forecast.Summary;
            try
            {
                // Save changes to the database
                await appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency issues if necessary
                if (!ProductExists(forecast.Date))
                {
                    return NotFound();
                }
                throw;
            }
            return Ok();
        }

        private bool ProductExists(DateOnly date)
        {
            return appDbContext.forecast.Any(e => e.Date == date);
        }
    }
}
