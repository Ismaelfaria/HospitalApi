using AutoMapper;
using HospitalApi.Entity;
using HospitalApi.Models;
using HospitalApi.Persistence.Context;


namespace HospitalApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalContext _context;
        private readonly IMapper _mapper;

        public PatientService(HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Patient CreatePatient(HospitalInputModel patientInput)
        {
            var createRegister = _mapper.Map<Patient>(patientInput);
            _context.Patients.Add(createRegister);
            createRegister.StartDate = DateTime.Now;
            _context.SaveChanges();

            return createRegister;
        }

        public void DeletePatient(int id)
        {
            var register = _context.Patients.SingleOrDefault(d => d.Id == id);

            register.Delete();
            _context.SaveChanges();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.Where(de => !de.IsDeleted).ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.SingleOrDefault(de => de.Id == id);
        }

        public void UpdatePatient(int id, HospitalInputModel patientInput)
        {
            var register = _context.Patients.SingleOrDefault(d => d.Id == id);

            register.Update(patientInput.Name, patientInput.Age, patientInput.Sexuality);
            _context.SaveChanges();
        }
    }
}
