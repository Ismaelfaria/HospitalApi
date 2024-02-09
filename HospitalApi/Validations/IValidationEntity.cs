using HospitalApi.Mappers.Models;

namespace HospitalApi.Validations
{
    public interface IValidationEntity
    {
        void ValidatePatient(HospitalInputModel patientInput);
    }
}
