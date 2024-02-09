using AutoMapper;
using HospitalApi.Mappers.Models;
using HospitalApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace HospitalApi.Controllers
{
    [Route("api/Hospital-Systemy")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public HospitalController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                var allRegistration = _patientService.GetAllPatients();

                return Ok(allRegistration);

            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetAll(Controller): {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var register = _patientService.GetPatientById(id);

                var viewModel = _mapper.Map<HospitalViewModel>(register);

                return Ok(viewModel);

            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreatingRegistry(HospitalInputModel patient)
        {
            try
            {
                var register = _patientService.CreatePatient(patient);

                return CreatedAtAction(nameof(GetById), new { id = register.Id }, patient);

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistry(int id, HospitalInputModel patient)
        {
            try
            {
                _patientService.UpdatePatient(id, patient);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do Put(Controller): {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedRegistry(int id)
        {
            try
            {
                _patientService.DeletePatient(id);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Delete(Controller): {ex.Message}");
            }
        }
    }
}
