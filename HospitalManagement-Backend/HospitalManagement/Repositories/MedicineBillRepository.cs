namespace HospitalManagement.Repositories
{
    public class MedicineBillRepository : IServiceRepository<MedicineBill, int>
    {
        IDataAccess<MedicineBill, int> medicineBillDataAccess;
        public MedicineBillRepository(IDataAccess<MedicineBill, int> dataAccess)
        {
            medicineBillDataAccess = dataAccess;
        }


        ResponseStatus<MedicineBill> IServiceRepository<MedicineBill, int>.CreateRecord(MedicineBill entity)
        {
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                response.Record = medicineBillDataAccess.Create(entity);
                response.Message = "MedicineBill created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<MedicineBill> IServiceRepository<MedicineBill, int>.DeleteRecord(int id)
        {
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                response.Record = medicineBillDataAccess.Delete(id);
                response.Message = $"MedicineBill with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<MedicineBill> IServiceRepository<MedicineBill, int>.GetRecord(int id)
        {
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                response.Record = medicineBillDataAccess.Get(id);
                response.Message = $"MedicineBill with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<MedicineBill> IServiceRepository<MedicineBill, int>.GetRecords()
        {
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                response.Records = medicineBillDataAccess.Get();
                response.Message = $"All MedicineBills read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<MedicineBill> IServiceRepository<MedicineBill, int>.UpdateRecord(int id, MedicineBill entity)
        {
            ResponseStatus<MedicineBill> response = new ResponseStatus<MedicineBill>();
            try
            {
                response.Record = medicineBillDataAccess.Update(id, entity);
                response.Message = $"MedicineBill with id: {id} updated succesfully";
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
