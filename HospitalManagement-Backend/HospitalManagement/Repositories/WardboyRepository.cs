namespace HospitalManagement.Repositories
{
    public class WardboyRepository : IServiceRepository<Wardboy, int>
    {
        IDataAccess<Wardboy, int> wardboyDataAccess;
        public WardboyRepository(IDataAccess<Wardboy, int> dataAccess)
        {
            wardboyDataAccess = dataAccess;
        }


        ResponseStatus<Wardboy> IServiceRepository<Wardboy, int>.CreateRecord(Wardboy entity)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
            try
            {
                response.Record = wardboyDataAccess.Create(entity);
                response.Message = "Wardboy created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<Wardboy> IServiceRepository<Wardboy, int>.DeleteRecord(int id)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
            try
            {
                response.Record = wardboyDataAccess.Delete(id);
                response.Message = $"Wardboy with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Wardboy> IServiceRepository<Wardboy, int>.GetRecord(int id)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
            try
            {
                response.Record = wardboyDataAccess.Get(id);
                response.Message = $"Wardboy with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Wardboy> IServiceRepository<Wardboy, int>.GetRecords()
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
            try
            {
                response.Records = wardboyDataAccess.Get();
                response.Message = $"All Wardboys read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Wardboy> IServiceRepository<Wardboy, int>.UpdateRecord(int id, Wardboy entity)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
            try
            {
                response.Record = wardboyDataAccess.Update(id, entity);
                response.Message = $"Wardboy with id: {id} updated succesfully";
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
