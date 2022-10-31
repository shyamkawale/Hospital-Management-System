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
    public class WardboyDataAccess : IDataAccess<Wardboy, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public WardboyDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Wardboy IDataAccess<Wardboy, int>.Create(Wardboy entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Wardboy Values ({entity.WardboyId}, '{entity.Name}', '{entity.Email}', {entity.MobileNo}, {entity.WardId})";
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

        Wardboy IDataAccess<Wardboy, int>.Delete(int id)
        {
            Wardboy wardboy = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Wardboy where WardboyId={id}";
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
            return wardboy;
        }

        IEnumerable<Wardboy> IDataAccess<Wardboy, int>.Get()
        {
            List<Wardboy> wardboyList = new List<Wardboy>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Wardboy";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    wardboyList.Add(new Wardboy()
                    {
                        WardboyId = Convert.ToInt32(reader["WardboyId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        WardId = Convert.ToInt32(reader["WardId"]),
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
            return wardboyList;
        }

        Wardboy IDataAccess<Wardboy, int>.Get(int id)
        {
            Wardboy wardboy = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select WardboyId, Name, Email, MobileNo, WardId from Wardboy where WardboyId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    wardboy = new Wardboy()
                    {
                        WardboyId = Convert.ToInt32(reader["WardboyId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        WardId = Convert.ToInt32(reader["WardId"]),
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
            return wardboy;
        }

        Wardboy IDataAccess<Wardboy, int>.Update(int id, Wardboy entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Wardboy Set Name='{entity.Name}', Email='{entity.Email}',MobileNo={entity.MobileNo}, WardId={entity.WardId} where WardboyId={id}";
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
