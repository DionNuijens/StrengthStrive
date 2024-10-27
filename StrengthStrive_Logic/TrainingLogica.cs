using StrengthStrive_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrengthStriveDTO;
using Interfaces;

namespace StrengthStrive_Logic
{
    public class TrainingLogica 
    {
        private readonly ITraining _training;
        private readonly IOefeningDal _oefening;

        public TrainingLogica(ITraining training, IOefeningDal oefening)
        {
            _training = training;
            _oefening = oefening;
        }

        public List<TrainingModel> GetAll()
        {
            List<TrainingModel> trainingen = new List<TrainingModel>();
            try
            {

            foreach (var item in _training.GetAll())
            {
                TrainingModel newItem = new TrainingModel();
                newItem.id = item.id;
                newItem.training_naam = item.training_naam;

                trainingen.Add(newItem);
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine("BLL Error: " + ex.Message);

                throw;
            }

            return trainingen;
        }

        public void TrainingCreateLogica(string training_naam)
        {

            _training.TrainingCreateDal(training_naam);
        }



        public void TrainingAddOefeningLogica(int id, int OefeningId, int sets )
        {
            _training.AddOefeningDal(id, OefeningId, sets);
        }

        public void TrainingDeleteLogica(int id)
        {
            _training.DeleteBy(id);
        }   

        public TrainingModel TrainingAddOefeningLogica(int id, string training_naam)
        {
            TrainingModel trainingModel = new TrainingModel();


            List<OefeningDTO> allExercises = _oefening.GetAllOefeningenDal();

            foreach (var item in allExercises)
            {
                Training_oefeningModel NewItem = new Training_oefeningModel();
                NewItem.set = 0;
                NewItem.Oefening.Oefening_naam = item.oefening_naam;
                NewItem.Oefening.Id = item.id;

                trainingModel.Training_oefening.Add(NewItem);
            }

            return (trainingModel);
        }

        public TrainingModel TrainingDetailsLogica(int id, string training_naam)
        {
            TrainingModel trainingModel = new TrainingModel();


            try
            {

                var items = _training.TrainingDetailsDal(id, training_naam)?.Training_oefening;


           

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        Training_oefeningModel NewItem = new Training_oefeningModel();
                        NewItem.set = item.set;
                        NewItem.Oefening.Oefening_naam = item.Oefening.oefening_naam;
                        NewItem.Oefening.Id = item.Oefening.id;

                        trainingModel.Training_oefening.Add(NewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("BLL Error: " + ex.Message);

                throw;
            }


            return (trainingModel);
        }
    }
}
