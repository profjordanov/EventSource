using System;

namespace EventSource.Api.Commands
{
    public class ReceiveCommand
    {
        public Guid Identifier { get; set; }

        public string Data { get; set; }
    }
}