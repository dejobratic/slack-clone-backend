using System;

namespace SlackClone.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
    }
}
