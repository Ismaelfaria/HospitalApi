using HospitalApi.Entity;
using HospitalApi.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace HospitalApi.Controllers
{
    [Route("api/Hospital-Systemy")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalContext _context;

        public HospitalController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allRegistration = _context.Patients.Where(p => !p.IsDeleted).ToList();

            return Ok(allRegistration);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var register = _context.Patients.SingleOrDefault(p => p.Id == id);

            if(register == null)
            {
                return NotFound();
            }

            return Ok(register);
        }

        [HttpPost]
        public IActionResult CreatingRegistry(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistry(int id, Patient patient)
        {
            var register = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (register == null)
            {
                return NotFound();
            }

            register.Update(patient.Name, patient.Age, patient.Sexuality);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedRegistry(int id)
        {
            var register = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (register == null)
            {
                return NotFound();
            }

            register.Delete();

            _context.SaveChanges();

            return NoContent();
        }
    }
}
