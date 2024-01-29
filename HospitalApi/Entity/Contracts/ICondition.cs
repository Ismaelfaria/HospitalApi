namespace HospitalApi.Entity.Contracts
{
    public interface ICondition
    {
        int IdCondition { get; set; }
        string ColorOfUrgency { get; set; }
        int PatientId { get; set; }
    }
}
