using System;

namespace TelemetryDependencies.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public int MessageId { get; set; }
        public int Length { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}