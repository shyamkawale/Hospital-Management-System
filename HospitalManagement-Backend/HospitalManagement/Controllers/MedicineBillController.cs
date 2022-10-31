using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineBillController : ControllerBase
    {
        private readonly IServiceRepository<MedicineBill, int> medicineBillRepo;
        public MedicineBillController(IServiceRepository<MedicineBill, int> repo)
        {
            medicineBillRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
                response = medicineBillRepo.GetRecords();
                return Ok(response.Records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpGet("MedicineBillsByBillId/{id}")]
        public IActionResult GetMedicineBillsByBillId(int id)
        {
            try
            {
                ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
                response = medicineBillRepo.GetRecords();
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
                ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
                response = medicineBillRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(MedicineBill medicineBill)
        {
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                response = medicineBillRepo.CreateRecord(medicineBill);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, MedicineBill medicineBill)
        {
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = medicineBillRepo.UpdateRecord(id, medicineBill);
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
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                response = medicineBillRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpDelete("DeleteMedicineBillsByBillId/{id}")]
        public IActionResult DeleteMedicineBillsByBillId(int id)
        {
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                var medicineBillsResponse = medicineBillRepo.GetRecords();
                var medicineBillsList = medicineBillsResponse.Records.ToList();
                for (int i = 0; i < medicineBillsList.Count(); i++)
                {
                    if (medicineBillsList[i].BillId == id)
                    {
                        response = medicineBillRepo.DeleteRecord(medicineBillsList[i].MedicineBillId);
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
