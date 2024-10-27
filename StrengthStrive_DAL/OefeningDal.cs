using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using MySql.Data.MySqlClient;
using StrengthStriveDTO;

namespace StrengthStrive_DAL
{
    public class OefeningDal : IOefeningDal
    {
        private readonly string connString;
        public OefeningDal(string connectionString)
        {
             connString = connectionString;
        }

        public List<OefeningDTO> GetAllOefeningenDal()
        {


            List<OefeningDTO> oefeningen = new List<OefeningDTO>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    con.Open();

                    string query = "SELECT * FROM oefening";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OefeningDTO oefening = new OefeningDTO();
                                oefening.id = Convert.ToInt32(reader["id"]);
                                oefening.oefening_naam = Convert.ToString(reader["oefening_naam"]);
                                oefeningen.Add(oefening);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {

                Console.WriteLine("DAL Error: " + ex.Message);


                throw;
            }

            return oefeningen;
        }

        public void OefeningAddDal(string oefening_naam)
        {

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                string query = "INSERT INTO oefening (oefening_naam) VALUES (@oefening_naam)";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@oefening_naam", oefening_naam); 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void OefeningChangedDal(int id, string oefening_naam)
        {

            string connString = "Server = 127.0.01; Database=StrengthStrive;Uid=root;";
            try
            {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                string query = "UPDATE oefening SET oefening_naam = @oefening_naam WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@oefening_naam", oefening_naam);

                    cmd.ExecuteNonQuery();
                }
            }

            }
            catch (Exception ex)
            { 
                Console.WriteLine("DAL Error: " + ex.Message);

                throw;
            }
        }

        public void OefeningDeleteDal(int id)
        {
            string connString = "Server = 127.0.01; Database=StrengthStrive;Uid=root;";
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = "DELETE FROM oefening WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
