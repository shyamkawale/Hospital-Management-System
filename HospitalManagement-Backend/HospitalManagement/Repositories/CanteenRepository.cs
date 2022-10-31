namespace HospitalManagement.Repositories
{
    public class CanteenRepository : IServiceRepository<Canteen, int>
    {
        IDataAccess<Canteen, int> canteenDataAccess;
        public CanteenRepository(IDataAccess<Canteen, int> dataAccess)
        {
            canteenDataAccess = dataAccess;
        }


        ResponseStatus<Canteen> IServiceRepository<Canteen, int>.CreateRecord(Canteen entity)
        {
            ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
            try
            {
                response.Record = canteenDataAccess.Create(entity);
                response.Message = "Canteen created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<Canteen> IServiceRepository<Canteen, int>.DeleteRecord(int id)
        {
            ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
            try
            {
                response.Record = canteenDataAccess.Delete(id);
                response.Message = $"Canteen with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Canteen> IServiceRepository<Canteen, int>.GetRecord(int id)
        {
            ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
            try
            {
                response.Record = canteenDataAccess.Get(id);
                response.Message = $"Canteen with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Canteen> IServiceRepository<Canteen, int>.GetRecords()
        {
            ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
            try
            {
                response.Records = canteenDataAccess.Get();
                response.Message = $"All Canteens read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Canteen> IServiceRepository<Canteen, int>.UpdateRecord(int id, Canteen entity)
        {
            ResponseStatus<Canteen> response = new ResponseStatus<Canteen>();
            try
            {
                response.Record = canteenDataAccess.Update(id, entity);
                response.Message = $"Canteen with id: {id} updated succesfully";
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
