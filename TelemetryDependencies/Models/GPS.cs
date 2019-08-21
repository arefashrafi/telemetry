using System.ComponentModel.DataAnnotations;

namespace TelemetryDependencies.Models
{
    public class Gps

    {
        [Key] public int Id { get; set; }

        public int DeviceId { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Alt { get; set; }
        public double Speed { get; set; }
        public double Heading { get; set; }
        public double Gpsfix { get; set; }
        public double Dist { get; set; }
        public double Tdist { get; set; }
        public double Accx { get; set; }
        public double Accy { get; set; }
        public double Accz { get; set; }
        public double Gyrx { get; set; }
        public double Gyry { get; set; }
        public double Gyrz { get; set; }
        public string TimeStamp { get; set; }
    }
}