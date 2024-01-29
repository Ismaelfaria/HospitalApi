namespace HospitalApi.Entity.Contracts
{
    public interface IPatient
    {
         void Update(string name, int age, string sexuality);
         void Delete();
    }
}
