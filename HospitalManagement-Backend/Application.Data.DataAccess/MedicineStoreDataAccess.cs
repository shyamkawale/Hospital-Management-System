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
    public class MedicineStoreDataAccess : IDataAccess<MedicineStore, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public MedicineStoreDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        MedicineStore IDataAccess<MedicineStore, int>.Create(MedicineStore entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into MedicineStore Values ({entity.MedicineId}, '{entity.Name}', {entity.Price})";
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

        MedicineStore IDataAccess<MedicineStore, int>.Delete(int id)
        {
            MedicineStore medicineStore = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From MedicineStore where MedicineId={id}";
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
            return medicineStore;
        }

        IEnumerable<MedicineStore> IDataAccess<MedicineStore, int>.Get()
        {
            List<MedicineStore> medicineStoreList = new List<MedicineStore>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from MedicineStore";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    medicineStoreList.Add(new MedicineStore()
                    {
                        MedicineId = Convert.ToInt32(reader["MedicineId"]),
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
            return medicineStoreList;
        }

        MedicineStore IDataAccess<MedicineStore, int>.Get(int id)
        {
            MedicineStore medicineStore = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select MedicineId, Name, Price from MedicineStore where MedicineId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    medicineStore = new MedicineStore()
                    {
                        MedicineId = Convert.ToInt32(reader["MedicineId"]),
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
            return medicineStore;
        }

        MedicineStore IDataAccess<MedicineStore, int>.Update(int id, MedicineStore entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update MedicineStore Set Name='{entity.Name}', Price={entity.Price} where MedicineId={id}";
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
