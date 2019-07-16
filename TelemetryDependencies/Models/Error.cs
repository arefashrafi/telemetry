// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Error.cs" company="JU Solar Team">
//   Aref Ashrafi
// </copyright>
// <summary>
//   Defines the Error type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TelemetryDependencies.Models
{
    public class Error
    {
        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
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