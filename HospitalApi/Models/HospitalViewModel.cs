using HospitalApi.Entity;

namespace HospitalApi.Models
{
    public class HospitalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sexuality { get; set; }
        public DateTime StartDate { get; set; }
        public Condition Condition { get; set; }
    }
}
