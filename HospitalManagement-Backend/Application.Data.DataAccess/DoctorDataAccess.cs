using Application.Dal.Contract;
using Application.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class DoctorDataAccess : IDataAccess<Doctor, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public DoctorDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Doctor IDataAccess<Doctor, int>.Create(Doctor entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Doctor Values ({entity.DoctorId}, '{entity.Name}', '{entity.Email}', {entity.MobileNo}, '{entity.Specialization}', {entity.Fees}, '{entity.Type}')";
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

        Doctor IDataAccess<Doctor, int>.Delete(int id)
        {
            Doctor doctor = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Doctor where DoctorId={id}";
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
            return doctor;
        }

        IEnumerable<Doctor> IDataAccess<Doctor, int>.Get()
        {
            List<Doctor> doctorList = new List<Doctor>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Doctor";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctorList.Add(new Doctor()
                    {
                        DoctorId = Convert.ToInt32(reader["DoctorId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Specialization = reader["Specialization"].ToString(),
                        Fees = Convert.ToDecimal(reader["Fees"]),
                        Type = reader["Type"].ToString()
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
            return doctorList;
        }

        Doctor IDataAccess<Doctor, int>.Get(int id)
        {
            Doctor doctor = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select DoctorId, Name, Email, MobileNo, Specialization, Fees, Type from Doctor where DoctorId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctor = new Doctor()
                    {
                        DoctorId = Convert.ToInt32(reader["DoctorId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Specialization = reader["Specialization"].ToString(),
                        Fees = Convert.ToDecimal(reader["Fees"]),
                        Type = reader["Type"].ToString()
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
            return doctor;
        }

        Doctor IDataAccess<Doctor, int>.Update(int id, Doctor entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Doctor Set Name='{entity.Name}', Email='{entity.Email}',MobileNo={entity.MobileNo}, Specialization='{entity.Specialization}', Fees={entity.Fees}, Type='{entity.Type}' where DoctorId={id}";
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