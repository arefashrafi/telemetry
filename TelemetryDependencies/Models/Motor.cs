// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Motor.cs" company="JU Solar Team">
//   Aref Ashrafi
// </copyright>
// <summary>
//   Defines the Motor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace TelemetryDependencies.Models
{
    /// <summary>
    ///     The motor.
    /// </summary>
    public class Motor
    {
        public int Id { get; set; }
        public int BatteryVoltage { get; set; }
        public int BatteryCurrent { get; set; }
        public int CurrentDirection { get; set; }
        public int MotorCurrent { get; set; }
        public int TempControl { get; set; }
        public int TempMotor { get; set; }
        public int MotorRPM { get; set; }
        public int OutputDuty { get; set; }
        public int OutputDutyType { get; set; }
        public int MotorDriveMode { get; set; }
        public int FailModeInfo1 { get; set; }
        public int FailModeInfo2 { get; set; }
        public int PresentCorePos { get; set; }
        public int FailModeInfo { get; set; }


        /// <summary>
        ///     Gets or sets the time.
        /// </summary>
        public string Time { get; set; }
    }
}