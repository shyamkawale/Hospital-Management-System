using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineStoreController : ControllerBase
    {
        private readonly IServiceRepository<MedicineStore, int> medicineStoreRepo;
        public MedicineStoreController(IServiceRepository<MedicineStore, int> repo)
        {
            medicineStoreRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
                response = medicineStoreRepo.GetRecords();
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
                ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
                response = medicineStoreRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(MedicineStore medicineStore)
        {
            ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
            try
            {
                response = medicineStoreRepo.CreateRecord(medicineStore);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, MedicineStore medicineStore)
        {
            ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = medicineStoreRepo.UpdateRecord(id, medicineStore);
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
            ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
            try
            {
                response = medicineStoreRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
    }
}
