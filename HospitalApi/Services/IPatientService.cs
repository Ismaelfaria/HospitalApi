using HospitalApi.Entity;
using HospitalApi.Models;

namespace HospitalApi.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        Patient CreatePatient(HospitalInputModel patientInput);
        void UpdatePatient(int id, HospitalInputModel patientInput);
        void DeletePatient(int id);

        
    }
}
