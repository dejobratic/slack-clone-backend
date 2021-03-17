﻿using System;

namespace SlackClone.Core.Models
{
    public class Channel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid CreatorId { get; set; }
    }
}