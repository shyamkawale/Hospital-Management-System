namespace HospitalManagement.Repositories
{
    public class CanteenBillRepository : IServiceRepository<CanteenBill, int>
    {
        IDataAccess<CanteenBill, int> canteenBillDataAccess;
        public CanteenBillRepository(IDataAccess<CanteenBill, int> dataAccess)
        {
            canteenBillDataAccess = dataAccess;
        }


        ResponseStatus<CanteenBill> IServiceRepository<CanteenBill, int>.CreateRecord(CanteenBill entity)
        {
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                response.Record = canteenBillDataAccess.Create(entity);
                response.Message = "CanteenBill created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<CanteenBill> IServiceRepository<CanteenBill, int>.DeleteRecord(int id)
        {
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                response.Record = canteenBillDataAccess.Delete(id);
                response.Message = $"CanteenBill with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<CanteenBill> IServiceRepository<CanteenBill, int>.GetRecord(int id)
        {
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                response.Record = canteenBillDataAccess.Get(id);
                response.Message = $"CanteenBill with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<CanteenBill> IServiceRepository<CanteenBill, int>.GetRecords()
        {
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                response.Records = canteenBillDataAccess.Get();
                response.Message = $"All CanteenBills read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<CanteenBill> IServiceRepository<CanteenBill, int>.UpdateRecord(int id, CanteenBill entity)
        {
            ResponseStatus<CanteenBill> response = new ResponseStatus<CanteenBill>();
            try
            {
                response.Record = canteenBillDataAccess.Update(id, entity);
                response.Message = $"CanteenBill with id: {id} updated succesfully";
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
