using HospitalApi.Entity.Contracts;

namespace HospitalApi.Entity
{
    public class Condition : ICondition
    {
        public int IdCondition { get; set; }
        public string ColorOfUrgency { get; set; }
        public int PatientId { get; set; }
    }
}
