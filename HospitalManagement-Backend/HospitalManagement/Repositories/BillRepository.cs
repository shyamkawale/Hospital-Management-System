namespace HospitalManagement.Repositories
{
    public class BillRepository : IServiceRepository<Bill, int>
    {
        IDataAccess<Bill, int> billDataAccess;
        public BillRepository(IDataAccess<Bill, int> dataAccess)
        {
            billDataAccess = dataAccess;
        }


        ResponseStatus<Bill> IServiceRepository<Bill, int>.CreateRecord(Bill entity)
        {
            ResponseStatus<Bill> response = new ResponseStatus<Bill>();
            try
            {
                response.Record = billDataAccess.Create(entity);
                response.Message = "Bill created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<Bill> IServiceRepository<Bill, int>.DeleteRecord(int id)
        {
            ResponseStatus<Bill> response = new ResponseStatus<Bill>();
            try
            {
                response.Record = billDataAccess.Delete(id);
                response.Message = $"Bill with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Bill> IServiceRepository<Bill, int>.GetRecord(int id)
        {
            ResponseStatus<Bill> response = new ResponseStatus<Bill>();
            try
            {
                response.Record = billDataAccess.Get(id);
                response.Message = $"Bill with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Bill> IServiceRepository<Bill, int>.GetRecords()
        {
            ResponseStatus<Bill> response = new ResponseStatus<Bill>();
            try
            {
                response.Records = billDataAccess.Get();
                response.Message = $"All Bills read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Bill> IServiceRepository<Bill, int>.UpdateRecord(int id, Bill entity)
        {
            ResponseStatus<Bill> response = new ResponseStatus<Bill>();
            try
            {
                response.Record = billDataAccess.Update(id, entity);
                response.Message = $"Bill with id: {id} updated succesfully";
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
