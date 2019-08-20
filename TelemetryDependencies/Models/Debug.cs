using System.ComponentModel.DataAnnotations;

namespace TelemetryDependencies.Models
{
    public class Debug
    {
        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the exception source.
        /// </summary>
        public string ExceptionSource { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the time.
        /// </summary>
        public string Time { get; set; }
    }
}