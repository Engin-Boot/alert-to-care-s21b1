

namespace Backend.Models
{
    public class PatientVitalsModels
    {
        public string IcuId { get; set; }
        public string Layout { get; set; }
        //public List<BedModel> Beds { get; set; }
        public int NoOfBeds { get; set; }
        public int MaxBeds { get; set; }

        public int BedsCounter { get; set; }
    }
}
