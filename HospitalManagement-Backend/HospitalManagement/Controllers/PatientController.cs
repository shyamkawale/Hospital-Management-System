using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IServiceRepository<Patient, int> patientRepo;
        public PatientController(IServiceRepository<Patient, int> repo)
        {
            patientRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<Patient> response = new ResponseStatus<Patient>();
                response = patientRepo.GetRecords();
                return Ok(response.Records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ResponseStatus<Patient> response = new ResponseStatus<Patient>();
                response = patientRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(Patient patient)
        {
            ResponseStatus<Patient> response = new ResponseStatus<Patient>();
            try
            {
                response = patientRepo.CreateRecord(patient);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Patient patient)
        {
            ResponseStatus<Patient> response = new ResponseStatus<Patient>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = patientRepo.UpdateRecord(id, patient);
                    return Ok(response);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseStatus<Patient> response = new ResponseStatus<Patient>();
            try
            {
                response = patientRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpGet("PatientsByCategory/{category}")]
        public IActionResult GetPatientsByCategory(string category)
        {
            try
            {
                ResponseStatus<Patient> response = new ResponseStatus<Patient>();
                response = patientRepo.GetRecords();
                List<Patient> records = new List<Patient>();
                if (category.Equals("IPD")) {
                    records = response.Records.Where(pat => pat.IsAdmitted == true).ToList();
                }
                else {
                    records = response.Records.Where(pat => pat.IsAdmitted == false).ToList();
                }
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpGet("PatientByDoctorId/{id}")]
        public IActionResult GetPatientByDoctorId(int id)
        {
            try
            {
                ResponseStatus<Patient> response = new ResponseStatus<Patient>();
                response = patientRepo.GetRecords();
                List<Patient> records = new List<Patient>();
                records = response.Records.Where(pat => pat.AssignedDoctorId == id).ToList();
                
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpGet("PatientByRoomId/{id}")]
        public IActionResult GetPatientByWardId(int id)
        {
            try
            {
                ResponseStatus<Patient> response = new ResponseStatus<Patient>();
                response = patientRepo.GetRecords();
                List<Patient> records = new List<Patient>();
                records = response.Records.Where(pat => pat.RoomId == id).ToList();

                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
    }
}
