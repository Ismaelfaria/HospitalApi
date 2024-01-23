namespace HospitalApi.Entity
{
    public class Condition
    {
        public int IdCondition { get; set; }
        public string ColorOfUrgency { get; set; }
        public int IdPatient { get; set; }
        public Patient Patient { get; set; }
    }
}
