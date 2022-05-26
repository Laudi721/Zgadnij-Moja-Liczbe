using System;

namespace NumberGuessing.Models
{
    public class Score
    {
        public Score(Guid sessionId)
        {
            SessionId = sessionId;
            GameStart = DateTime.UtcNow;
        }

        public Guid SessionId { get; }

        public DateTime GameStart { get; }

        public int GuessCount { get; set; }

        public double CalculateGameTime() => (DateTime.UtcNow - GameStart).TotalMinutes;
    }
}
