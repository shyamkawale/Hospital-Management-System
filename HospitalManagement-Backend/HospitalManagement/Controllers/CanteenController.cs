using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanteenController : ControllerBase
    {
        private readonly IServiceRepository<Canteen, int> canteenRepo;
        public CanteenController(IServiceRepository<Canteen, int> repo)
        {
            canteenRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
                response = canteenRepo.GetRecords();
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
                ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
                response = canteenRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(Canteen canteen)
        {
            ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
            try
            {
                response = canteenRepo.CreateRecord(canteen);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Canteen canteen)
        {
            ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = canteenRepo.UpdateRecord(id, canteen);
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
            ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
            try
            {
                response = canteenRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
    }
}
