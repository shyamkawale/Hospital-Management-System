using Application.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanteenBillController : ControllerBase
    {
        private readonly IServiceRepository<CanteenBill, int> canteenBillRepo;
        public CanteenBillController(IServiceRepository<CanteenBill, int> repo)
        {
            canteenBillRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
                response = canteenBillRepo.GetRecords();
                return Ok(response.Records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpGet("CanteenBillsByBillId/{id}")]
        public IActionResult GetCanteenBillsByBillId(int id)
        {
            try
            {
                ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
                response = canteenBillRepo.GetRecords();
                var records = response.Records.Where(bill => bill.BillId == id).ToList();
                return Ok(records);
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
                ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
                response = canteenBillRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(CanteenBill canteenBill)
        {
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                response = canteenBillRepo.CreateRecord(canteenBill);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, CanteenBill canteenBill)
        {
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = canteenBillRepo.UpdateRecord(id, canteenBill);
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
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                response = canteenBillRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpDelete("DeleteCanteenBillsByBillId/{id}")]
        public IActionResult DeleteCanteenBillsByBillId(int id)
        {
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                var canteenBillsResponse = canteenBillRepo.GetRecords();
                var canteenBillsList = canteenBillsResponse.Records.ToList();
                for (int i = 0; i < canteenBillsList.Count(); i++)
                {
                    if (canteenBillsList[i].BillId == id)
                    {
                        response = canteenBillRepo.DeleteRecord(canteenBillsList[i].CanteenBillId);
                    }
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
    }
}
