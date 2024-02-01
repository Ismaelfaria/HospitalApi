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
            var allRegistration = _patientService.GetAllPatients();

            var viewModel = _mapper.Map<List<HospitalViewModel>>(allRegistration);

            return Ok(viewModel);
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
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpPost]
        public IActionResult CreatingRegistry(HospitalInputModel patient)
        {
            try
            {

                var register = _patientService.CreatePatient(patient);

                var viewModel = _mapper.Map<HospitalViewModel>(register);

                return CreatedAtAction(nameof(GetById), new { id = viewModel.Id }, patient);

            }
            catch (Exception)
            {
                return StatusCode(400);
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
            catch (Exception)
            {
                return StatusCode(404);
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
            catch (Exception)
            {
                return StatusCode(404);
            }
        }
    }
}
