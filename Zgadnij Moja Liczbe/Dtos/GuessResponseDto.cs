using System;

namespace NumberGuessing.Dtos
{
    public class GuessResponseDto
    {
        public Guid SessionId { get; set; }

        public int GuessCount { get; set; }

        public string Result { get; set; }
    }
}
