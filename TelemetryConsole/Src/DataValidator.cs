using FluentValidation;
using TelemetryDependencies.Models;

namespace TelemetryConsole
{
    public class MotorValidator : AbstractValidator<Motor>
    {
        public MotorValidator()
        {
            RuleFor(x => x.Time).NotNull();
            RuleFor(x => x.MotorCurrent).LessThan(1000);
            RuleFor(x => x.MotorDriveMode).LessThan(300);
            RuleFor(x => x.BatteryCurrent).LessThan(1000);
            RuleFor(x => x.BatteryVoltage).LessThan(1000);
            RuleFor(x => x.OutputDuty).LessThan(250);
            RuleFor(x => x.TempControl).LessThan(200);
            RuleFor(x => x.TempMotor).LessThan(200);
            RuleFor(x => x.FailModeInfo).LessThan(100);
            RuleFor(x => x.FailModeInfo2).LessThan(100);
            RuleFor(x => x.OutputDutyType).LessThan(100);
            RuleFor(x => x.PresentCorePos).LessThan(100);
            RuleFor(x => x.Gear).LessThan(300);
            RuleFor(x => x.MotorRpm).LessThan(5000);
        }
    }

    public class BmsValidator : AbstractValidator<Bms>
    {
        public BmsValidator()
        {
            RuleFor(x => x.Time).NotNull();
            RuleFor(x => x.Current).LessThan(1000);
            RuleFor(x => x.Soc).LessThan(125);
            RuleFor(x => x.Volt).LessThan(1000);
            RuleFor(x => x.CycleTime).LessThan(5000);
            RuleFor(x => x.MaxTemp).LessThan(300);
            RuleFor(x => x.MaxVolt).LessThan(5000);
            RuleFor(x => x.MinTemp).LessThan(300);
            RuleFor(x => x.MinVolt).LessThan(5000);
            RuleFor(x => x.RoundtripTm).LessThan(100);
            RuleFor(x => x.FWVersion).LessThan(100);
            RuleFor(x => x.MaxTempId).NotNull();
            RuleFor(x => x.MaxVoltId).NotNull();
            RuleFor(x => x.MinTempId).NotNull();
            RuleFor(x => x.MinVoltId).NotNull();
            RuleFor(x => x.MCUTemp).LessThan(1000);
        }
    }

    public class MpptValidator : AbstractValidator<MPPT>
    {
        public MpptValidator()
        {
            RuleFor(x => x.Time).NotNull();
            RuleFor(x => x.ControllerTemp).LessThan(300);
            RuleFor(x => x.DeviceId).LessThan(100);
            RuleFor(x => x.InputCurrent).LessThan(1000);
            RuleFor(x => x.OutputVoltage).LessThan(1000);
            RuleFor(x => x.InputVoltage).LessThan(1000);
        }
    }

    public class GpsValidator : AbstractValidator<Gps>
    {
        public GpsValidator()
        {
            RuleFor(x => x.TimeStamp).NotNull();
            RuleFor(x => x.TimeStamp).NotNull();
            RuleFor(x => x.Alt).LessThan(10000);
            RuleFor(x => x.DeviceId).LessThan(5);
        }
    }
}