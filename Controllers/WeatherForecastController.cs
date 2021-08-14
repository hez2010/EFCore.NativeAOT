using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace EFCore.NativeAOT.Controllers
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
        private readonly MyDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet, Route("")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            _context.Table1.Add(new Table1 { Message = "test" });
            await _context.SaveChangesAsync();

            var query = _context.Table1.Where(i => i.Message == "test");
            query = query.Where(i => i.Id >= 4);
            var result = await query.ToListAsync();

            foreach (var i in result)
            {
                Console.WriteLine((i.Id, i.Message));
            }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
