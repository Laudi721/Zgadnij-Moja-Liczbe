using System;

namespace NumberGuessing.Dtos
{
    public class ScoreDto
    {
        public Guid SessionId { get; set; }

        public int GuessCount { get; set; }

        public double GameTime { get; set; }
    }
}
