using HospitalApi.Entity;

namespace HospitalApi.Mappers.Models
{
    public class HospitalViewModel : HospitalModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public Condition Condition { get; set; }
    }
}
