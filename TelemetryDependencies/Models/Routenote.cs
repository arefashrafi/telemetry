// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BMS1.cs" company="JU Solar team">
//  Aref Ashrafi
// </copyright>
// <summary>
//   The bms 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace TelemetryDependencies.Models
{
    /// <summary>
    ///     The Battery Management System 1
    /// </summary>
    public class Routenote
    {
        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        public int UnixTime { get; set; }
        public string Time { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public decimal Alt { get; set; }
        public decimal Dist { get; set; }
    }
}