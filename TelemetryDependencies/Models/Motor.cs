// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Motor.cs" company="JU Solar Team">
//   Aref Ashrafi
// </copyright>
// <summary>
//   Defines the Motor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.ComponentModel.DataAnnotations;

namespace TelemetryDependencies.Models
{
    /// <summary>
    ///     The motor.
    /// </summary>
    public class Motor
    {
        [Key] public int Id { get; set; }

        public int BatteryVoltage { get; set; }

        public int BatteryCurrent { get; set; }

        public int BatteryCurrentDir { get; set; }

        public int MotorCurrent { get; set; }

        public int MotorCurrentDir { get; set; }

        public int TempControl { get; set; }

        public int TempMotor { get; set; }


        public int MotorRpm { get; set; }


        public int OutputDuty { get; set; }


        public int OutputDutyType { get; set; }


        public int MotorDriveMode { get; set; }


        public int FailModeInfo { get; set; }


        public int TempErrLevel { get; set; }


        public int PresentCorePos { get; set; }


        public int Gear { get; set; }

        public int FailModeInfo2 { get; set; }


        /// <summary>
        ///     Gets or sets the time.
        /// </summary>
        public string Time { get; set; }
    }
}