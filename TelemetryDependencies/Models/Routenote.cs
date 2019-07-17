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
        public int ID { get; set; }

        public int UNIX_TIME { get; set; }
        public string TIME { get; set; }
        public decimal LAT { get; set; }
        public decimal LONG { get; set; }
        public decimal ALT { get; set; }
        public decimal DIST { get; set; }
    }
}