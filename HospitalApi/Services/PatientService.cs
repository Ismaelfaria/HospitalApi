using AutoMapper;
using HospitalApi.Entity;
using HospitalApi.Mappers.Models;
using HospitalApi.Persistence.Context;
using HospitalApi.Repository;
using HospitalApi.Validations;


namespace HospitalApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IValidationEntity _validate;

        public PatientService(IPatientRepository patientRepository, IMapper mapper, IValidationEntity validate)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _validate = validate;
        }
        public Patient CreatePatient(HospitalInputModel patientInput)
        {
            try
            {
                _validate.ValidatePatient(patientInput);

                var createRegister = _mapper.Map<Patient>(patientInput);

                createRegister.StartDate = DateTime.Now;
                _patientRepository.Save(createRegister);
                return createRegister;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao criar o paciente.(Service)", ex);
            }

        }

        public void DeletePatient(int id)
        {
            try
            {
                _patientRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao deletar o paciente.(Service)", ex);
            }
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            try
            {
                return _patientRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao visualizar todos os paciente.(Service)", ex);
            }

        }

        public Patient GetPatientById(int id)
        {
            try
            {

                return _patientRepository.FindById(id);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao visualizar o paciente.(Service)", ex);
            }
        }

        public void UpdatePatient(int id, HospitalInputModel patientInput)
        {
            try
            {
                var createRegister = _mapper.Map<Patient>(patientInput);

                _patientRepository.Update(id, createRegister);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar os paciente.(Service)", ex);
            }
        }
    }
}
