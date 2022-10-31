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
    public class RoomDataAccess : IDataAccess<Room, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public RoomDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Room IDataAccess<Room, int>.Create(Room entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Room Values ({entity.RoomId}, '{entity.Name}', '{entity.IsAvailable}', {entity.Charge}, {entity.WardId})";
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

        Room IDataAccess<Room, int>.Delete(int id)
        {
            Room room = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Room where RoomId={id}";
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
            return room;
        }

        IEnumerable<Room> IDataAccess<Room, int>.Get()
        {
            List<Room> roomList = new List<Room>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Room";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    roomList.Add(new Room()
                    {
                        RoomId = Convert.ToInt32(reader["RoomId"]),
                        Name = reader["Name"].ToString(),
                        IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                        Charge = Convert.ToDecimal(reader["Charge"]),
                        WardId = Convert.ToInt32(reader["WardId"])
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
            return roomList;
        }

        Room IDataAccess<Room, int>.Get(int id)
        {
            Room room = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select RoomId, Name, IsAvailable, Charge, WardId from Room where RoomId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    room = new Room()
                    {
                        RoomId = Convert.ToInt32(reader["RoomId"]),
                        Name = reader["Name"].ToString(),
                        IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                        Charge = Convert.ToDecimal(reader["Charge"]),
                        WardId = Convert.ToInt32(reader["WardId"])
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
            return room;
        }

        Room IDataAccess<Room, int>.Update(int id, Room entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Room Set Name='{entity.Name}', IsAvailable='{entity.IsAvailable}',Charge={entity.Charge}, WardId={entity.WardId} where RoomId={id}";
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
