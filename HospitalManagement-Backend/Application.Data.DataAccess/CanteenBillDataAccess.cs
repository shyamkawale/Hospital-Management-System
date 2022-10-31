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
    public class CanteenBillDataAccess : IDataAccess<CanteenBill, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public CanteenBillDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        CanteenBill IDataAccess<CanteenBill, int>.Create(CanteenBill entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into CanteenBill Values ({entity.CanteenBillId}, {entity.BillId}, {entity.FoodId}, {entity.Quantity}, {entity.TotalPrice})";
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

        CanteenBill IDataAccess<CanteenBill, int>.Delete(int id)
        {
            CanteenBill canteenBill = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From CanteenBill where CanteenBillId={id}";
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
            return canteenBill;
        }

        IEnumerable<CanteenBill> IDataAccess<CanteenBill, int>.Get()
        {
            List<CanteenBill> canteenBillList = new List<CanteenBill>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from CanteenBill";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    canteenBillList.Add(new CanteenBill()
                    {
                        CanteenBillId = Convert.ToInt32(reader["CanteenBillId"]),
                        BillId = Convert.ToInt32(reader["BillId"]),
                        FoodId = Convert.ToInt32(reader["FoodId"]),
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
            return canteenBillList;
        }

        CanteenBill IDataAccess<CanteenBill, int>.Get(int id)
        {
            CanteenBill canteenBill = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select CanteenBillId, BillId, FoodId, Quantity, TotalPrice from CanteenBill where CanteenBillId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    canteenBill = new CanteenBill()
                    {
                        CanteenBillId = Convert.ToInt32(reader["CanteenBillId"]),
                        BillId = Convert.ToInt32(reader["BillId"]),
                        FoodId = Convert.ToInt32(reader["FoodId"]),
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
            return canteenBill;
        }

        CanteenBill IDataAccess<CanteenBill, int>.Update(int id, CanteenBill entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update CanteenBill Set BillId={entity.BillId}, FoodId={entity.FoodId}, Quantity={entity.Quantity}, TotalPrice={entity.TotalPrice} where CanteenBillId={id}";
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
