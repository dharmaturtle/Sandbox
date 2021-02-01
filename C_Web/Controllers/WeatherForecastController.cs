using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTypes;
using System.IO;
using System.Text;

namespace C_Web.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase {
    private static readonly string[] Summaries = new[] {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger) {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get() {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpPost]
    public string Index(Root item) {
      var sb = new StringBuilder();
      sb.Append(@"{
  ""fulfillmentMessages"": [
    {
        ""text"": {
          ""text"": [
            ""We received action \""");
      sb.Append(item.queryResult.action);
      sb.Append("\\\" and parameters ");
      sb.Append(item.queryResult.parameters.item);
      sb.Append(@"""
        ]
      }
    }
  ]
}");
      var asdf = sb.ToString();
      return asdf;
      //using (var reader = new StreamReader(Request.Body)) {
      //  var body = reader.ReadToEnd();
      //  System.Diagnostics.Debugger.Break();
      //  var ss = 5;
      //  // Do something
      //}
    }

  }

}
