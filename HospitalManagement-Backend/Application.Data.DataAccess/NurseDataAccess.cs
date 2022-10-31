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

namespace Application.Data.DataAccess
{
    public class NurseDataAccess: IDataAccess<Nurse, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public NurseDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Nurse IDataAccess<Nurse, int>.Create(Nurse entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Nurse Values ({entity.NurseId}, '{entity.Name}', '{entity.Email}', {entity.MobileNo}, {entity.Fees})";
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

        Nurse IDataAccess<Nurse, int>.Delete(int id)
        {
            Nurse nurse = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Nurse where NurseId={id}";
                int result = Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }
            return nurse;
        }

        IEnumerable<Nurse> IDataAccess<Nurse, int>.Get()
        {
            List<Nurse> nurseList = new List<Nurse>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Nurse";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    nurseList.Add(new Nurse()
                    {
                        NurseId = Convert.ToInt32(reader["NurseId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Fees = Convert.ToDecimal(reader["Fees"]),
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
            return nurseList;
        }

        Nurse IDataAccess<Nurse, int>.Get(int id)
        {
            Nurse nurse = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select NurseId, Name, Email, MobileNo, Fees from Nurse where NurseId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    nurse = new Nurse()
                    {
                        NurseId = Convert.ToInt32(reader["NurseId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Fees = Convert.ToDecimal(reader["Fees"]),
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
            return nurse;
        }

        Nurse IDataAccess<Nurse, int>.Update(int id, Nurse entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Nurse Set Name='{entity.Name}', Email='{entity.Email}',MobileNo={entity.MobileNo} Fees={entity.Fees} where NurseId={id}";
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
