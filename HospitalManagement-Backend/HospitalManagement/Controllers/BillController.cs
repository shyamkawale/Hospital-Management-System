using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IServiceRepository<Bill, int> billRepo;
        public BillController(IServiceRepository<Bill, int> repo)
        {
            billRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<Bill> response = new ResponseStatus<Bill>();
                response = billRepo.GetRecords();
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
                ResponseStatus<Bill> response = new ResponseStatus<Bill>();
                response = billRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(Bill bill)
        {
            ResponseStatus<Bill> response = new ResponseStatus<Bill>();
            try
            {
                response = billRepo.CreateRecord(bill);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Bill bill)
        {
            ResponseStatus<Bill> response = new ResponseStatus<Bill>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = billRepo.UpdateRecord(id, bill);
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
            ResponseStatus<Bill> response = new ResponseStatus<Bill>();
            try
            {
                response = billRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
    }
}
