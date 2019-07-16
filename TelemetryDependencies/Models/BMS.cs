// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BMS1.cs" company="JU Solar team">
//  Aref Ashrafi
// </copyright>
// <summary>
//   The bms 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


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
        public int Id { get; set; }

        public uint MinVolt { get; set; }
        public uint MinVoltId { get; set; }
        public uint MaxVolt { get; set; }
        public uint MaxVoltId { get; set; }
        public uint Volt { get; set; }
        public int Current { get; set; }
        public uint Status { get; set; }
        public uint Soc { get; set; }
        public int MinTemp { get; set; }
        public int MinTempId { get; set; }
        public int MaxTemp { get; set; }
        public int MaxTempId { get; set; }
        public uint FWVersion { get; set; }
        public uint CycleTime { get; set; }
        public int MCUTemp { get; set; }
        public uint RoundtripTm { get; set; }
        public string Time { get; set; }
    }
}