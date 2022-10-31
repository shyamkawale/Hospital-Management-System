using Application.Dal.Contract;
using Application.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Numerics;
using System.Xml.Linq;

namespace Application.Data.DataAccess
{
    public class PatientDataAccess : IDataAccess<Patient, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public PatientDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Patient IDataAccess<Patient, int>.Create(Patient entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                //Cmd.CommandType = CommandType.Text;
                //Cmd.CommandText = $"Insert into Patient Values ({entity.PatientId}, '{entity.FirstName}', '{entity.MiddleName}','{entity.LastName}', {entity.MobileNo}, '{entity.Email}', '{entity.Address}', '{entity.DateOfBirth}', '{entity.Gender}', '{entity.AgeType}', '{entity.IsAdmitted}', {entity.RoomId},{entity.BillId},{entity.AssignedDoctorId})";

                Cmd = new SqlCommand("INSERT INTO Patient VALUES (@PatientId,@FirstName,@MiddleName,@LastName,@MobileNo, @Email, @Address, @DateOfBirth,@Gender, @AgeType, @IsAdmitted, @RoomId, @BillId, @AssignedDoctorId )", Conn);
                Cmd.Parameters.Add(new SqlParameter("@PatientId", entity.PatientId));
                Cmd.Parameters.Add(new SqlParameter("@FirstName", entity.FirstName));
                Cmd.Parameters.Add(new SqlParameter("@MiddleName", entity.MiddleName));
                Cmd.Parameters.Add(new SqlParameter("@LastName", entity.LastName));
                Cmd.Parameters.Add(new SqlParameter("@MobileNo", entity.MobileNo));
                Cmd.Parameters.Add(new SqlParameter("@Email", entity.Email));
                Cmd.Parameters.Add(new SqlParameter("@Address", entity.Address));
                Cmd.Parameters.Add(new SqlParameter("@DateOfBirth", entity.DateOfBirth));
                Cmd.Parameters.Add(new SqlParameter("@Gender", entity.Gender));
                Cmd.Parameters.Add(new SqlParameter("@AgeType", entity.AgeType));
                Cmd.Parameters.Add(new SqlParameter("@IsAdmitted", entity.IsAdmitted));
                Cmd.Parameters.Add(new SqlParameter("@RoomId", entity.RoomId == null ? DBNull.Value: entity.RoomId));
                Cmd.Parameters.Add(new SqlParameter("@BillId", entity.BillId == null ? DBNull.Value : entity.BillId));
                Cmd.Parameters.Add(new SqlParameter("@AssignedDoctorId", entity.AssignedDoctorId == null ? DBNull.Value : entity.AssignedDoctorId));
                int result = Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return entity;
        }

        Patient IDataAccess<Patient, int>.Delete(int id)
        {
            Patient patient = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Patient where PatientId={id}";
                int result = Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }
            return patient;
        }

        IEnumerable<Patient> IDataAccess<Patient, int>.Get()
        {
            List<Patient> patientList = new List<Patient>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Patient";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    patientList.Add(new Patient()
                    {
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Gender = reader["Gender"].ToString(),
                        AgeType = reader["AgeType"].ToString(),
                        IsAdmitted = Convert.ToBoolean(reader["IsAdmitted"]),
                        AssignedDoctorId = reader["AssignedDoctorId"] == DBNull.Value ? null : Convert.ToInt32(reader["AssignedDoctorId"]),
                        BillId = reader["BillId"] == DBNull.Value ? null : Convert.ToInt32(reader["BillId"]),
                        RoomId = reader["RoomId"] == DBNull.Value ? null : Convert.ToInt32(reader["RoomId"])
                    });

                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return patientList;
        }

        Patient IDataAccess<Patient, int>.Get(int id)
        {
            Patient patient = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select PatientId, FirstName, MiddleName, LastName, MobileNo, Email, Address, DateOfBirth, Gender, AgeType, IsAdmitted, AssignedDoctorId, BillId, RoomId from Patient where PatientId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    patient = new Patient()
                    {
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Gender = reader["Gender"].ToString(),
                        AgeType = reader["AgeType"].ToString(),
                        IsAdmitted = Convert.ToBoolean(reader["IsAdmitted"]),
                        AssignedDoctorId = reader["AssignedDoctorId"] == DBNull.Value ? null : Convert.ToInt32(reader["AssignedDoctorId"]),
                        BillId = reader["BillId"] == DBNull.Value ? null : Convert.ToInt32(reader["BillId"]),
                        RoomId = reader["RoomId"] == DBNull.Value ? null : Convert.ToInt32(reader["RoomId"])
                    };
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return patient;
        }

        Patient IDataAccess<Patient, int>.Update(int id, Patient entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                //Cmd.CommandType = CommandType.Text;
                Cmd = new SqlCommand("Update Patient Set FirstName=@FirstName , MiddleName=@MiddleName ,LastName=@LastName ,MobileNo=@MobileNo , Email=@Email , Address=@Address , DateOfBirth=@DateOfBirth , Gender=@Gender , AgeType=@AgeType , IsAdmitted=@IsAdmitted , AssignedDoctorId=@AssignedDoctorId ,BillId=@BillId ,RoomId=@RoomId where PatientId=@id", Conn);
                //Cmd.CommandText = $"Update Patient Set FirstName='{entity.FirstName}', MiddleName='{entity.MiddleName}',LastName='{entity.LastName}',MobileNo={entity.MobileNo}, Email='{entity.Email}', Address='{entity.Address}', DateOfBirth='{entity.DateOfBirth}', Gender='{entity.Gender}', AgeType='{entity.AgeType}', IsAdmitted='{entity.IsAdmitted}', AssignedDoctorId={entity.AssignedDoctorId},BillId={entity.BillId},RoomId={entity.RoomId} where PatientId={id}";
                Cmd.Parameters.Add(new SqlParameter("@id", id));
                Cmd.Parameters.Add(new SqlParameter("@PatientId", entity.PatientId));
                Cmd.Parameters.Add(new SqlParameter("@FirstName", entity.FirstName));
                Cmd.Parameters.Add(new SqlParameter("@MiddleName", entity.MiddleName));
                Cmd.Parameters.Add(new SqlParameter("@LastName", entity.LastName));
                Cmd.Parameters.Add(new SqlParameter("@MobileNo", entity.MobileNo));
                Cmd.Parameters.Add(new SqlParameter("@Email", entity.Email));
                Cmd.Parameters.Add(new SqlParameter("@Address", entity.Address));
                Cmd.Parameters.Add(new SqlParameter("@DateOfBirth", entity.DateOfBirth));
                Cmd.Parameters.Add(new SqlParameter("@Gender", entity.Gender));
                Cmd.Parameters.Add(new SqlParameter("@AgeType", entity.AgeType));
                Cmd.Parameters.Add(new SqlParameter("@IsAdmitted", entity.IsAdmitted));
                Cmd.Parameters.Add(new SqlParameter("@RoomId", entity.RoomId == null ? DBNull.Value : entity.RoomId));
                Cmd.Parameters.Add(new SqlParameter("@BillId", entity.BillId == null ? DBNull.Value : entity.BillId));
                Cmd.Parameters.Add(new SqlParameter("@AssignedDoctorId", entity.AssignedDoctorId == null ? DBNull.Value : entity.AssignedDoctorId));
                int result = Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return entity;
        }
    }
}
