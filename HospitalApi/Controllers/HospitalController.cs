using AutoMapper;
using HospitalApi.Entity;
using HospitalApi.Models;
using HospitalApi.Persistence.Context;
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
        private readonly IMapper _mapper;

        public HospitalController(HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allRegistration = _context.Patients.Where(p => !p.IsDeleted).ToList();

            var viewModel = _mapper.Map<List<HospitalViewModel>>(allRegistration);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var register = _context.Patients.SingleOrDefault(p => p.Id == id);

            if(register == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<HospitalViewModel>(register);

            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult CreatingRegistry(HospitalInputModel patient)
        {

            var createRegister = _mapper.Map<Patient>(patient);

            _context.Patients.Add(createRegister);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = createRegister.Id }, createRegister);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistry(int id, HospitalInputModel patient)
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
