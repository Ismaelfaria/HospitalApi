using HospitalApi.Entity;
using HospitalApi.Mappers.Models;

namespace HospitalApi.Validations
{
    public class ValidationEntity : IValidationEntity
    {
        public void ValidatePatient(HospitalInputModel patientInput)
        {

            if (string.IsNullOrEmpty(patientInput.Name))
                throw new ArgumentException("O nome do paciente é obrigatório.");

            if (patientInput.Age < 0 || patientInput.Age > 150)
                throw new ArgumentException("A idade do paciente deve estar entre 0 e 150.");

        }
    }
}
