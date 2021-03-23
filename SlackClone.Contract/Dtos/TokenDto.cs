using System;

namespace SlackClone.Contract.Dtos
{
    public class TokenDto
    {
        public string Value { get; set; }
        public string Type { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
    }
}
