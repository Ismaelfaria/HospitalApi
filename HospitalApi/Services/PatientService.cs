using AutoMapper;
using FluentValidation;
using HospitalApi.Entity;
using HospitalApi.Mappers.Models;
using HospitalApi.Repository;

namespace HospitalApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<HospitalInputModel> _validator;

        public PatientService(IPatientRepository patientRepository, IMapper mapper, IValidator<HospitalInputModel> validator)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public Patient CreatePatient(HospitalInputModel patientInput)
        {
            var validationResult = _validator.Validate(patientInput);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar o paciente", validationResult.Errors);
            }
            var createCondition = _mapper.Map<Condition>(patientInput.Condition);
            var createRegister = _mapper.Map<Patient>(patientInput);

            createRegister.Condition = createCondition;
            createRegister.StartDate = DateTime.Now;
            _patientRepository.Save(createRegister);
            return createRegister;

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
