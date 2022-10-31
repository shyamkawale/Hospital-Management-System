namespace HospitalManagement.Repositories
{
    public class NurseRepository : IServiceRepository<Nurse, int>
    {
        IDataAccess<Nurse, int> nurseDataAccess;
        public NurseRepository(IDataAccess<Nurse, int> dataAccess)
        {
            nurseDataAccess = dataAccess;
        }


        ResponseStatus<Nurse> IServiceRepository<Nurse, int>.CreateRecord(Nurse entity)
        {
            ResponseStatus<Nurse> response = new ResponseStatus<Nurse>();
            try
            {
                response.Record = nurseDataAccess.Create(entity);
                response.Message = "Nurse created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<Nurse> IServiceRepository<Nurse, int>.DeleteRecord(int id)
        {
            ResponseStatus<Nurse> response = new ResponseStatus<Nurse>();
            try
            {
                response.Record = nurseDataAccess.Delete(id);
                response.Message = $"Nurse with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Nurse> IServiceRepository<Nurse, int>.GetRecord(int id)
        {
            ResponseStatus<Nurse> response = new ResponseStatus<Nurse>();
            try
            {
                response.Record = nurseDataAccess.Get(id);
                response.Message = $"Nurse with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Nurse> IServiceRepository<Nurse, int>.GetRecords()
        {
            ResponseStatus<Nurse> response = new ResponseStatus<Nurse>();
            try
            {
                response.Records = nurseDataAccess.Get();
                response.Message = $"All Nurses read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Nurse> IServiceRepository<Nurse, int>.UpdateRecord(int id, Nurse entity)
        {
            ResponseStatus<Nurse> response = new ResponseStatus<Nurse>();
            try
            {
                response.Record = nurseDataAccess.Update(id, entity);
                response.Message = $"Nurse with id: {id} updated succesfully";
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
