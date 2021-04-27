using System;

namespace EventSource.Api.Commands
{
    public class FlagCommand
    {
        public Guid Identifier { get; set; }

        public bool Flag { get; set; }
    }
}