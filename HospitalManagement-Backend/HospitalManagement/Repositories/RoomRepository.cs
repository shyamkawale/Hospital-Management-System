namespace HospitalManagement.Repositories
{
    public class RoomRepository : IServiceRepository<Room, int>
    {
        IDataAccess<Room, int> roomDataAccess;
        public RoomRepository(IDataAccess<Room, int> dataAccess)
        {
            roomDataAccess = dataAccess;
        }


        ResponseStatus<Room> IServiceRepository<Room, int>.CreateRecord(Room entity)
        {
            ResponseStatus<Room> response = new ResponseStatus<Room>();
            try
            {
                response.Record = roomDataAccess.Create(entity);
                response.Message = "Room created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<Room> IServiceRepository<Room, int>.DeleteRecord(int id)
        {
            ResponseStatus<Room> response = new ResponseStatus<Room>();
            try
            {
                response.Record = roomDataAccess.Delete(id);
                response.Message = $"Room with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Room> IServiceRepository<Room, int>.GetRecord(int id)
        {
            ResponseStatus<Room> response = new ResponseStatus<Room>();
            try
            {
                response.Record = roomDataAccess.Get(id);
                response.Message = $"Room with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Room> IServiceRepository<Room, int>.GetRecords()
        {
            ResponseStatus<Room> response = new ResponseStatus<Room>();
            try
            {
                response.Records = roomDataAccess.Get();
                response.Message = $"All Rooms read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Room> IServiceRepository<Room, int>.UpdateRecord(int id, Room entity)
        {
            ResponseStatus<Room> response = new ResponseStatus<Room>();
            try
            {
                response.Record = roomDataAccess.Update(id, entity);
                response.Message = $"Room with id: {id} updated succesfully";
                response.StatusCode = 204;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
