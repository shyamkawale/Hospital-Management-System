using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardboyController : ControllerBase
    {
        private readonly IServiceRepository<Wardboy, int> wardboyRepo;
        public WardboyController(IServiceRepository<Wardboy, int> repo)
        {
            wardboyRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
                response = wardboyRepo.GetRecords();
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
                ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
                response = wardboyRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(Wardboy wardboy)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
            try
            {
                response = wardboyRepo.CreateRecord(wardboy);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Wardboy wardboy)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = wardboyRepo.UpdateRecord(id, wardboy);
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
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
            try
            {
                response = wardboyRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
    }
}
