using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IServiceRepository<Doctor, int> doctorRepo;
        public DoctorController(IServiceRepository<Doctor, int> repo)
        {
            doctorRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
                response = doctorRepo.GetRecords();
                return Ok(response.Records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpGet("DoctorBySpec/{spec}")]
        public IActionResult GetDoctorBySpec(string spec)
        {
            try
            {
                ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
                response = doctorRepo.GetRecords();
                var record = response.Records.Where(doc => doc.Specialization.Equals(spec));
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpGet("DoctorByType/{type}")]
        public IActionResult GetDoctorByType(string type)
        {
            try
            {
                ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
                response = doctorRepo.GetRecords();
                var record = response.Records.Where(doc => doc.Type.Equals(type));
                return Ok(record);
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
                ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
                response = doctorRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(Doctor doctor)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
            try
            {
                response = doctorRepo.CreateRecord(doctor);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Doctor doctor)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = doctorRepo.UpdateRecord(id, doctor);
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
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
            try
            {
                response = doctorRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
    }
}
