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
    public class Bms
    {
        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        public int MinVolt { get; set; }
        public int MinVoltId { get; set; }
        public int MaxVolt { get; set; }
        public int MaxVoltId { get; set; }
        public int Volt { get; set; }
        public int Current { get; set; }
        public int Status { get; set; }
        public int Soc { get; set; }
        public int MinTemp { get; set; }
        public int MinTempId { get; set; }
        public int MaxTemp { get; set; }
        public int MaxTempId { get; set; }
        public int FWVersion { get; set; }
        public int CycleTime { get; set; }
        public int MCUTemp { get; set; }
        public int RoundtripTm { get; set; }
        public string Time { get; set; }
    }
}