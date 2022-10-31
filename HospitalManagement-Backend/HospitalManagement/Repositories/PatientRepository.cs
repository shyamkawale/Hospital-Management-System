namespace HospitalManagement.Repositories
{

    public class PatientRepository : IServiceRepository<Patient, int>
    {
        IDataAccess<Patient, int> patientDataAccess;
        public PatientRepository(IDataAccess<Patient, int> dataAccess)
        {
            patientDataAccess = dataAccess;
        }


        ResponseStatus<Patient> IServiceRepository<Patient, int>.CreateRecord(Patient entity)
        {
            ResponseStatus<Patient> response = new ResponseStatus<Patient>();
            try
            {
                response.Record = patientDataAccess.Create(entity);
                response.Message = "Patient created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<Patient> IServiceRepository<Patient, int>.DeleteRecord(int id)
        {
            ResponseStatus<Patient> response = new ResponseStatus<Patient>();
            try
            {
                response.Record = patientDataAccess.Delete(id);
                response.Message = $"Patient with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Patient> IServiceRepository<Patient, int>.GetRecord(int id)
        {
            ResponseStatus<Patient> response = new ResponseStatus<Patient>();
            try
            {
                response.Record = patientDataAccess.Get(id);
                response.Message = $"Patient with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Patient> IServiceRepository<Patient, int>.GetRecords()
        {
            ResponseStatus<Patient> response = new ResponseStatus<Patient>();
            try
            {
                response.Records = patientDataAccess.Get();
                response.Message = $"All Patients read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Patient> IServiceRepository<Patient, int>.UpdateRecord(int id, Patient entity)
        {
            ResponseStatus<Patient> response = new ResponseStatus<Patient>();
            try
            {
                response.Record = patientDataAccess.Update(id, entity);
                response.Message = $"Patient with id: {id} updated succesfully";
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
