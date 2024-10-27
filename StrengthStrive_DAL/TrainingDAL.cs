using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrengthStriveDTO;
using MySql.Data.MySqlClient;
using Interfaces;

namespace StrengthStrive_DAL
{

    public class TrainingDAL : ITraining
    {

        private readonly string connString;
        public TrainingDAL(string connectionString)
        {
            connString = connectionString;
        }

        public List<TrainingDTO> GetAll()
        {
            List<TrainingDTO> trainingen = new List<TrainingDTO>();

            try
            {

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string query = "SELECT * FROM training";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TrainingDTO training = new TrainingDTO();
                            training.id = Convert.ToInt32(reader["id"]);
                            training.training_naam = Convert.ToString(reader["training_naam"]);
                            trainingen.Add(training);
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
            return trainingen;
        }

        public void TrainingCreateDal(string training_naam)
        {

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                string query = "INSERT INTO training (training_naam) VALUES (@training_naam)";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@training_naam", training_naam);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBy(int id)
        {

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
            

                string deleteTrainingOefeningQuery = "DELETE FROM training_oefening WHERE training_id = @trainingId";
                using (MySqlCommand deleteTrainingOefeningCommand = new MySqlCommand(deleteTrainingOefeningQuery, connection))
                {
                    deleteTrainingOefeningCommand.Parameters.AddWithValue("@trainingId", id);
                    deleteTrainingOefeningCommand.ExecuteNonQuery();
                }

                string deleteTrainingQuery = "DELETE FROM training WHERE id = @id";
                using (MySqlCommand deleteTrainingCommand = new MySqlCommand(deleteTrainingQuery, connection))
                {
                    deleteTrainingCommand.Parameters.AddWithValue("@id", id);
                    deleteTrainingCommand.ExecuteNonQuery();
                }
            }
        }




        public void AddOefeningDal(int id, int oefeningId, int sets)
        {

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                string query = "INSERT INTO training_oefening (training_id, oefening_id, sets) VALUES (@training_id, @oefening_id, @sets)";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@training_id", id);
                    cmd.Parameters.AddWithValue("@oefening_id", oefeningId);
                    cmd.Parameters.AddWithValue("@sets", sets);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TrainingDTO TrainingDetailsDal(int id, string training_naam)
        {
            TrainingDTO training = null;


            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    connection.Open();

                    string query = "SELECT t.id, t.training_naam, te.sets, te.oefening_id, oefening_naam FROM training_oefening te " +
                                   "INNER JOIN training t ON te.training_id = t.id " +
                                   "INNER JOIN oefening o ON te.oefening_id = o.id " +
                                   "WHERE te.training_id = @trainingId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@trainingId", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            training = null;
                            while (reader.Read())
                            {
                                if (training == null)
                                {
                                    training = new TrainingDTO
                                    {
                                        id = Convert.ToInt32(reader["id"]),
                                        training_naam = reader["training_naam"].ToString(),
                                        Training_oefening = new List<Training_oefeningDTO>()
                                    };
                                }

                                Training_oefeningDTO to = new Training_oefeningDTO
                                {
                                    set = Convert.ToInt32(reader["sets"]),
                                    oefening_id = Convert.ToInt32(reader["oefening_id"]),
                                    Oefening = new OefeningDTO
                                    {
                                        oefening_naam = reader["oefening_naam"].ToString()
                                    },
                                    Training = training
                                };

                                training.Training_oefening.Add(to);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("DAL Error: " + ex.Message);

                throw ex;
            }

            return (training);
        }


    }
}
