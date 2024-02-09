using HospitalApi.Entity;
using HospitalApi.Mappers.Models;

namespace HospitalApi.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> FindAll();
        Patient FindById(int id);
        Patient Save(Patient patient);
        void Update(int id, Patient patient);
        void Delete(int id);

    }
}
