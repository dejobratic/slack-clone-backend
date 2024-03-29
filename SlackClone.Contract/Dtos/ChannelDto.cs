﻿using System;

namespace SlackClone.Contract.Dtos
{
    public class ChannelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatorId { get; set; }
        public Guid[] SubscriberIds { get; set; }
    }
}
