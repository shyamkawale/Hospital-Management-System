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
    public class BillDataAccess : IDataAccess<Bill, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public BillDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Bill IDataAccess<Bill, int>.Create(Bill entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                //Cmd.CommandType = CommandType.Text;
                var OPDFees = (entity.OPD_Fees == null) ? 0 : entity.OPD_Fees;
                var Doctor_Fees = (entity.Doctor_Fees == null) ? 0 : entity.Doctor_Fees;
                var Other_Fees = (entity.Other_Fees == null) ? 0 : entity.Other_Fees;
                var MedicineCharges = (entity.MedicineCharges == null) ? 0 : entity.MedicineCharges;
                var CanteenCharges = (entity.CanteenCharges == null) ? 0 : entity.CanteenCharges;
                var IPD_Advance_Fees = (entity.IPD_Advance_Fees == null) ? 0 : entity.IPD_Advance_Fees;
                var RoomCharges = (entity.RoomCharges == null) ? 0 : entity.RoomCharges;
                entity.Total_Fees = OPDFees + Doctor_Fees + Other_Fees + MedicineCharges + CanteenCharges + IPD_Advance_Fees + RoomCharges;

                //Cmd.CommandText = $"Insert into Bill Values ({entity.BillId}, {entity.OPD_Fees}, {entity.Doctor_Fees}, {entity.Other_Fees}, {entity.MedicineCharges}, {entity.CanteenCharges}, {entity.IPD_Advance_Fees}, {entity.RoomCharges},{entity.Total_Fees})";
                Cmd = new SqlCommand("INSERT INTO Bill VALUES (@BillId , @OPD_Fees , @Doctor_Fees , @Other_Fees , @Total_Fees , @MedicineCharges , @CanteenCharges , @RoomCharges , @IPD_Advance_Fees )", Conn);
                Cmd.Parameters.Add(new SqlParameter("@BillId", entity.BillId));
                Cmd.Parameters.Add(new SqlParameter("@OPD_Fees", entity.OPD_Fees == null ? DBNull.Value : entity.OPD_Fees));
                Cmd.Parameters.Add(new SqlParameter("@Doctor_Fees", entity.Doctor_Fees == null ? DBNull.Value : entity.Doctor_Fees));
                Cmd.Parameters.Add(new SqlParameter("@Other_Fees", entity.Other_Fees == null ? DBNull.Value : entity.Other_Fees));
                Cmd.Parameters.Add(new SqlParameter("@MedicineCharges", entity.MedicineCharges == null ? DBNull.Value : entity.MedicineCharges));
                Cmd.Parameters.Add(new SqlParameter("@CanteenCharges", entity.CanteenCharges == null ? DBNull.Value : entity.CanteenCharges));
                Cmd.Parameters.Add(new SqlParameter("@IPD_Advance_Fees", entity.IPD_Advance_Fees == null ? DBNull.Value : entity.IPD_Advance_Fees));
                Cmd.Parameters.Add(new SqlParameter("@RoomCharges", entity.RoomCharges == null ? DBNull.Value : entity.RoomCharges));
                Cmd.Parameters.Add(new SqlParameter("@Total_Fees", entity.Total_Fees == null ? DBNull.Value : entity.Total_Fees));
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

        Bill IDataAccess<Bill, int>.Delete(int id)
        {
            Bill bill = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Bill where BillId={id}";
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
            return bill;
        }

        IEnumerable<Bill> IDataAccess<Bill, int>.Get()
        {
            List<Bill> billList = new List<Bill>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Bill";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    billList.Add(new Bill()
                    {
                        BillId = Convert.ToInt32(reader["BillId"]),
                        OPD_Fees = reader["OPD_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["OPD_Fees"]),
                        Doctor_Fees = reader["Doctor_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["Doctor_Fees"]),
                        Other_Fees = reader["Other_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["Other_Fees"]),
                        MedicineCharges = reader["MedicineCharges"] == DBNull.Value ? null : Convert.ToDecimal(reader["MedicineCharges"]),
                        CanteenCharges = reader["CanteenCharges"] == DBNull.Value ? null : Convert.ToDecimal(reader["CanteenCharges"]),
                        RoomCharges = reader["RoomCharges"] == DBNull.Value ? null : Convert.ToDecimal(reader["RoomCharges"]),
                        IPD_Advance_Fees = reader["IPD_Advance_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["IPD_Advance_Fees"]),
                        Total_Fees = reader["Total_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["Total_Fees"])
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
            return billList;
        }

        Bill IDataAccess<Bill, int>.Get(int id)
        {
            Bill bill = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select BillId, OPD_Fees, Doctor_Fees, Other_Fees, MedicineCharges, CanteenCharges, IPD_Advance_Fees, RoomCharges, Total_Fees  from Bill where BillId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    bill = new Bill()
                    {
                        BillId = Convert.ToInt32(reader["BillId"]),
                        OPD_Fees = reader["OPD_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["OPD_Fees"]),
                        Doctor_Fees = reader["Doctor_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["Doctor_Fees"]),
                        Other_Fees = reader["Other_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["Other_Fees"]),
                        MedicineCharges = reader["MedicineCharges"] == DBNull.Value ? null : Convert.ToDecimal(reader["MedicineCharges"]),
                        CanteenCharges = reader["CanteenCharges"] == DBNull.Value ? null : Convert.ToDecimal(reader["CanteenCharges"]),
                        RoomCharges = reader["RoomCharges"] == DBNull.Value ? null : Convert.ToDecimal(reader["RoomCharges"]),
                        IPD_Advance_Fees = reader["IPD_Advance_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["IPD_Advance_Fees"]),
                        Total_Fees = reader["Total_Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["Total_Fees"])
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
            return bill;
        }

        Bill IDataAccess<Bill, int>.Update(int id, Bill entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                //Cmd.CommandType = CommandType.Text;
                var OPDFees = (entity.OPD_Fees == null) ? 0 : entity.OPD_Fees;
                var Doctor_Fees = (entity.Doctor_Fees == null) ? 0 : entity.Doctor_Fees;
                var Other_Fees = (entity.Other_Fees == null) ? 0 : entity.Other_Fees;
                var MedicineCharges = (entity.MedicineCharges == null) ? 0 : entity.MedicineCharges;
                var CanteenCharges = (entity.CanteenCharges == null) ? 0 : entity.CanteenCharges;
                var IPD_Advance_Fees = (entity.IPD_Advance_Fees == null) ? 0 : entity.IPD_Advance_Fees;
                var RoomCharges = (entity.RoomCharges == null) ? 0 : entity.RoomCharges;
                entity.Total_Fees = OPDFees + Doctor_Fees + Other_Fees + MedicineCharges + CanteenCharges + IPD_Advance_Fees + RoomCharges;
                //Cmd.CommandText = $"Update Bill Set OPD_Fees={entity.OPD_Fees}, Doctor_Fees={entity.Doctor_Fees},Other_Fees={entity.Other_Fees}, MedicineCharges={entity.MedicineCharges}, CanteenCharges={entity.CanteenCharges},RoomCharges={entity.RoomCharges},IPD_Advance_Fees={entity.IPD_Advance_Fees}, Total_Fees={entity.Total_Fees} where BillId={id}";
                Cmd = new SqlCommand("Update Bill Set OPD_Fees=@OPD_Fees, Doctor_Fees=@Doctor_Fees,Other_Fees=@Other_Fees , MedicineCharges=@MedicineCharges , CanteenCharges=@CanteenCharges , RoomCharges=@RoomCharges , IPD_Advance_Fees=@IPD_Advance_Fees , Total_Fees=@Total_Fees where BillId=@id", Conn);
                Cmd.Parameters.Add(new SqlParameter("@id", id));
                Cmd.Parameters.Add(new SqlParameter("@OPD_Fees", entity.OPD_Fees == null ? DBNull.Value : entity.OPD_Fees));
                Cmd.Parameters.Add(new SqlParameter("@Doctor_Fees", entity.Doctor_Fees == null ? DBNull.Value : entity.Doctor_Fees));
                Cmd.Parameters.Add(new SqlParameter("@Other_Fees", entity.Other_Fees == null ? DBNull.Value : entity.Other_Fees));
                Cmd.Parameters.Add(new SqlParameter("@MedicineCharges", entity.MedicineCharges == null ? DBNull.Value : entity.MedicineCharges));
                Cmd.Parameters.Add(new SqlParameter("@CanteenCharges", entity.CanteenCharges == null ? DBNull.Value : entity.CanteenCharges));
                Cmd.Parameters.Add(new SqlParameter("@IPD_Advance_Fees", entity.IPD_Advance_Fees == null ? DBNull.Value : entity.IPD_Advance_Fees));
                Cmd.Parameters.Add(new SqlParameter("@RoomCharges", entity.RoomCharges == null ? DBNull.Value : entity.RoomCharges));
                Cmd.Parameters.Add(new SqlParameter("@Total_Fees", entity.Total_Fees == null ? DBNull.Value : entity.Total_Fees));

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
