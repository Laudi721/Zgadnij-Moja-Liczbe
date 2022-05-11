using System;

namespace NumberGuessing.Dtos
{
    public class GuessDto
    {
        public Guid SessionId { get; set; }

        public int Number { get; set; }
    }
}
