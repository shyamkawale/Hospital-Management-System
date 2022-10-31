using Application.Entities;

namespace HospitalManagement.Repositories
{
    public class DoctorRepository : IServiceRepository<Doctor, int>
    {
        IDataAccess<Doctor, int> doctorDataAccess;
        public DoctorRepository(IDataAccess<Doctor, int> dataAccess)
        {
            doctorDataAccess = dataAccess;
        }


        ResponseStatus<Doctor> IServiceRepository<Doctor, int>.CreateRecord(Doctor entity)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
            try
            {
                response.Record = doctorDataAccess.Create(entity);
                response.Message = "Doctor created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<Doctor> IServiceRepository<Doctor, int>.DeleteRecord(int id)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
            try
            {
                response.Record = doctorDataAccess.Delete(id);
                response.Message = $"Doctor with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Doctor> IServiceRepository<Doctor, int>.GetRecord(int id)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
            try
            {
                response.Record = doctorDataAccess.Get(id);
                response.Message = $"Doctor with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Doctor> IServiceRepository<Doctor, int>.GetRecords()
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
            try
            {
                response.Records = doctorDataAccess.Get();
                response.Message = $"All Doctors read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Doctor> IServiceRepository<Doctor, int>.UpdateRecord(int id, Doctor entity)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
            try
            {
                response.Record = doctorDataAccess.Update(id, entity);
                response.Message = $"Doctor with id: {id} updated succesfully";
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
