using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetryDependencies.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public byte MessageId { get; set; }
        public byte Length { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}
