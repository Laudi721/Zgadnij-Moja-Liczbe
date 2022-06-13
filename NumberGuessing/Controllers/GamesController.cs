using Microsoft.AspNetCore.Mvc;
using NumberGuessing.Dtos;
using NumberGuessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGuessing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private static readonly List<Score> _games = new();
        private static int _number;

        public GamesController()
        {
        }

        [HttpGet, Route("Start")]
        public Guid Start()
        {
            var sessionId = Guid.NewGuid();
            _number = new Random().Next(1, 100);

            _games.Add(new Score(sessionId));

            return sessionId;
        }

        [HttpPost, Route("Guess")]
        public ActionResult<GuessResponseDto> Guess([FromBody] GuessDto guess)
        {
            var game = _games.SingleOrDefault(a => a.SessionId == guess.SessionId);

            if (game is null)
                return BadRequest();

            game.GuessCount++;

            var result = guess.Number > _number ? "too big" : guess.Number < _number ? "too small" : "winner";

            return Ok(new GuessResponseDto
            {
                SessionId = game.SessionId,
                GuessCount = game.GuessCount,
                Result = result
            });
        }

        [HttpGet, Route("HiScores")]
        public IEnumerable<ScoreDto> HiScores()
        {
            return _games.OrderByDescending(a => a.GuessCount).Take(10).Select(a => new ScoreDto
            {
                SessionId = a.SessionId,
                GuessCount = a.GuessCount,
                GameTime = a.CalculateGameTime()
            });
        }
    }
}
