using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IServiceRepository<Ward, int> wardRepo;
        public WardController(IServiceRepository<Ward, int> repo)
        {
            wardRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<Ward> response = new ResponseStatus<Ward>();
                response = wardRepo.GetRecords();
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
                ResponseStatus<Ward> response = new ResponseStatus<Ward>();
                response = wardRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(Ward ward)
        {
            ResponseStatus<Ward> response = new ResponseStatus<Ward>();
            try
            {
                response = wardRepo.CreateRecord(ward);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Ward ward)
        {
            ResponseStatus<Ward> response = new ResponseStatus<Ward>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = wardRepo.UpdateRecord(id, ward);
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
            ResponseStatus<Ward> response = new ResponseStatus<Ward>();
            try
            {
                response = wardRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
    }
}
