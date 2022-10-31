namespace HospitalManagement.Repositories
{
    public class WardRepository : IServiceRepository<Ward, int>
    {
        IDataAccess<Ward, int> wardDataAccess;
        public WardRepository(IDataAccess<Ward, int> dataAccess)
        {
            wardDataAccess = dataAccess;
        }


        ResponseStatus<Ward> IServiceRepository<Ward, int>.CreateRecord(Ward entity)
        {
            ResponseStatus<Ward> response = new ResponseStatus<Ward>();
            try
            {
                response.Record = wardDataAccess.Create(entity);
                response.Message = "Ward created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<Ward> IServiceRepository<Ward, int>.DeleteRecord(int id)
        {
            ResponseStatus<Ward> response = new ResponseStatus<Ward>();
            try
            {
                response.Record = wardDataAccess.Delete(id);
                response.Message = $"Ward with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Ward> IServiceRepository<Ward, int>.GetRecord(int id)
        {
            ResponseStatus<Ward> response = new ResponseStatus<Ward>();
            try
            {
                response.Record = wardDataAccess.Get(id);
                response.Message = $"Ward with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Ward> IServiceRepository<Ward, int>.GetRecords()
        {
            ResponseStatus<Ward> response = new ResponseStatus<Ward>();
            try
            {
                response.Records = wardDataAccess.Get();
                response.Message = $"All Wards read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Ward> IServiceRepository<Ward, int>.UpdateRecord(int id, Ward entity)
        {
            ResponseStatus<Ward> response = new ResponseStatus<Ward>();
            try
            {
                response.Record = wardDataAccess.Update(id, entity);
                response.Message = $"Ward with id: {id} updated succesfully";
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
