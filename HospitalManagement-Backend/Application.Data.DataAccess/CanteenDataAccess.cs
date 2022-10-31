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
    public class CanteenDataAccess : IDataAccess<Canteen, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public CanteenDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Canteen IDataAccess<Canteen, int>.Create(Canteen entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Canteen Values ({entity.FoodId}, '{entity.Name}', {entity.Price})";
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

        Canteen IDataAccess<Canteen, int>.Delete(int id)
        {
            Canteen canteen = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Canteen where FoodId={id}";
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
            return canteen;
        }

        IEnumerable<Canteen> IDataAccess<Canteen, int>.Get()
        {
            List<Canteen> canteenList = new List<Canteen>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Canteen";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    canteenList.Add(new Canteen()
                    {
                        FoodId = Convert.ToInt32(reader["FoodId"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
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
            return canteenList;
        }

        Canteen IDataAccess<Canteen, int>.Get(int id)
        {
            Canteen canteen = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select FoodId, Name, Price from Canteen where FoodId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    canteen = new Canteen()
                    {
                        FoodId = Convert.ToInt32(reader["FoodId"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
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
            return canteen;
        }

        Canteen IDataAccess<Canteen, int>.Update(int id, Canteen entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Canteen Set Name='{entity.Name}', Price={entity.Price} where FoodId={id}";
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
