using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IServiceRepository<Room, int> roomRepo;
        public RoomController(IServiceRepository<Room, int> repo)
        {
            roomRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<Room> response = new ResponseStatus<Room>();
                response = roomRepo.GetRecords();
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
                ResponseStatus<Room> response = new ResponseStatus<Room>();
                response = roomRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post(Room room)
        {
            ResponseStatus<Room> response = new ResponseStatus<Room>();
            try
            {
                response = roomRepo.CreateRecord(room);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Room room)
        {
            ResponseStatus<Room> response = new ResponseStatus<Room>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = roomRepo.UpdateRecord(id, room);
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
            ResponseStatus<Room> response = new ResponseStatus<Room>();
            try
            {
                response = roomRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }

        [HttpGet("RoomsByWard/{id}")]
        public IActionResult GetRoomsByWard(int id)
        {
            try
            {
                ResponseStatus<Room> response = new ResponseStatus<Room>();
                response = roomRepo.GetRecords();

                var records = response.Records.Where(room => room.WardId == id);
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
    }
}
