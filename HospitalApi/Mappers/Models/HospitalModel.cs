using HospitalApi.Entity;

namespace HospitalApi.Mappers.Models
{
    public abstract class HospitalModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sexuality { get; set; }
    }
}
