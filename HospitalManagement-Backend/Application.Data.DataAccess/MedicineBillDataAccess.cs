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
    public class MedicineBillDataAccess : IDataAccess<MedicineBill, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public MedicineBillDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        MedicineBill IDataAccess<MedicineBill, int>.Create(MedicineBill entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into MedicineBill Values ({entity.MedicineBillId}, {entity.BillId}, {entity.MedicineId}, {entity.Quantity}, {entity.TotalPrice})";
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

        MedicineBill IDataAccess<MedicineBill, int>.Delete(int id)
        {
            MedicineBill medicineBill = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From MedicineBill where MedicineBillId={id}";
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
            return medicineBill;
        }

        IEnumerable<MedicineBill> IDataAccess<MedicineBill, int>.Get()
        {
            List<MedicineBill> medicineBillList = new List<MedicineBill>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from MedicineBill";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    medicineBillList.Add(new MedicineBill()
                    {
                        MedicineBillId = Convert.ToInt32(reader["MedicineBillId"]),
                        BillId = Convert.ToInt32(reader["BillId"]),
                        MedicineId = Convert.ToInt32(reader["MedicineId"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        TotalPrice = Convert.ToDecimal(reader["TotalPrice"])
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
            return medicineBillList;
        }

        MedicineBill IDataAccess<MedicineBill, int>.Get(int id)
        {
            MedicineBill medicineBill = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select MedicineBillId, BillId, MedicineId, Quantity, TotalPrice from MedicineBill where MedicineBillId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    medicineBill = new MedicineBill()
                    {
                        MedicineBillId = Convert.ToInt32(reader["MedicineBillId"]),
                        BillId = Convert.ToInt32(reader["BillId"]),
                        MedicineId = Convert.ToInt32(reader["MedicineId"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        TotalPrice = Convert.ToDecimal(reader["TotalPrice"])
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
            return medicineBill;
        }

        MedicineBill IDataAccess<MedicineBill, int>.Update(int id, MedicineBill entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update MedicineBill Set BillId={entity.BillId}, MedicineId={entity.MedicineId}, Quantity={entity.Quantity}, TotalPrice={entity.TotalPrice}' where MedicineBillId={id}";
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
