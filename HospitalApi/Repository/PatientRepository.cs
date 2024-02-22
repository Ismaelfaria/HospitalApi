using AutoMapper;
using HospitalApi.Entity;
using HospitalApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalContext _context;

        public PatientRepository(HospitalContext context)
        {
            _context = context;
        }
        public IEnumerable<Patient> FindAll()
        {
            return _context.Patients
                .Where(de => !de.IsDeleted)
                .Include(de => de.Condition)
                .ToList();        
        }

        public Patient FindById(int id)
        {
            return _context.Patients
                .Include(de => de.Condition)
                .SingleOrDefault(de => de.Id == id);
        }
        public Patient Save(Patient patient)
        {
            _context.Patients.Add(patient);

            _context.SaveChanges();

            return patient;
        }
        public void Update(int id, Patient patient)
        {
            var register = _context.Patients.SingleOrDefault(d => d.Id == id);

            register.Update(patient.Name, patient.Age, patient.Sexuality);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var register = _context.Patients.SingleOrDefault(d => d.Id == id);

            register.Delete();
            _context.SaveChanges();
        }
    }
}
