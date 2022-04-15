using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgadnij_Moja_Liczbe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZgadnijMojaLiczbeController : ControllerBase
    {
        [HttpGet]
        public string Start()
        {
            var rnd = new Random();
            var id = new char[30];
            var builder = new StringBuilder();

            for (var i = 0; i < 30; i++)
            {
                id[i] = (char) rnd.Next(33, 126);
                builder.Append(id[i]);
            }

            return builder.ToString();
        }

        [HttpPost("/guess")]
        public IEnumerable<GuessNumber> Guess([FromBody] int guess, [FromBody] string idSession)
        {
            var rng = new Random();
            var count = 0;
            var number = rng.Next(1,5);

            while (guess != number)
            {
                count++;
            }

            return Enumerable.Range(0,1).Select(i => new GuessNumber
            {
                id = idSession,
                count = count,
                number = number
            });
        }
    }
}
