namespace TelemetryDependencies.Models
{
    public class Gps

    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public double LAT { get; set; }
        public double LONG { get; set; }
        public double ALT { get; set; }
        public double SPEED { get; set; }
        public double HEADING { get; set; }
        public double GPSFIX { get; set; }
        public double DIST { get; set; }
        public double TDIST { get; set; }
        public double ACCX { get; set; }
        public double ACCY { get; set; }
        public double ACCZ { get; set; }
        public double GYRX { get; set; }
        public double GYRY { get; set; }
        public double GYRZ { get; set; }
        public string TimeStamp { get; set; }
    }
}