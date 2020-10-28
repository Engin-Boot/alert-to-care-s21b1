
namespace Backend.Models
{
    public class VitalsModel
    {
        public string PatientId { get; set; }
        public string VitalId { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }
    }
}
