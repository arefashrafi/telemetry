using System.ComponentModel.DataAnnotations;

namespace TelemetryDependencies.Models
{
    public class MPPT
    {
        [Key] public int Id { get; set; }

        public int DeviceId { get; set; }
        public int InputCurrent { get; set; }
        public int InputVoltage { get; set; }
        public int OutputVoltage { get; set; }
        public int OutputCurrent { get; set; }
        public int ControllerTemp { get; set; }
        public string Time { get; set; }
    }
}