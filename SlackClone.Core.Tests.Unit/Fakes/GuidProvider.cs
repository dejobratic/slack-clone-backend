using System;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public static class GuidProvider
    {
        public static readonly Guid ChannelId
            = new Guid("3EFC11BE-6652-4E62-A353-0E781504CCA4");

        public static readonly Guid MessageId
            = new Guid("89509919-F9C0-4FD8-9A1E-B76F475D8581");

        public static readonly Guid UserId
            = new Guid("782B62FA-D26E-469D-8E1C-BED76689C72B");
    }
}
