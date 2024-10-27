using Microsoft.AspNetCore.Mvc;
using StrengthStrive.Models;
using StrengthStrive_Logic;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using StrengthStrive_DAL;

namespace StrengthStrive.Controllers
{
    public class TrainingController : Controller
    {
        private readonly TrainingLogica trainingLogica;

        public TrainingController (TrainingLogica trainingLogica)
        {
            this.trainingLogica = trainingLogica;
        }

        public IActionResult Index()
        {
            List<TrainingViewModel> trainingen = new List<TrainingViewModel>();
            try
            {
            foreach (var item in trainingLogica.GetAll())
            {
                TrainingViewModel newItem = new TrainingViewModel();
                newItem.Id = item.id;
                newItem.TrainingNaam = item.training_naam;

                trainingen.Add(newItem);
            }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Controller Error: " + ex.Message);

                ViewBag.ErrorMessage = "Controller Error: " + ex.Message;
            }

            return View(trainingen);
        }

        public IActionResult TrainingCreate() { return View(); }

        public IActionResult TrainingAdd(string training_naam)
        {

			foreach (var item in trainingLogica.GetAll())
			{
				if (training_naam == item.training_naam )
				{
                    ViewBag.ErrorMessage = "Deze bestaat al oekel";
                    return View("TrainingCreate");

				}
			}
            if (!ModelState.IsValid)
            {
                return View("TrainingCreate");
            }
            trainingLogica.TrainingCreateLogica(training_naam); 
			return RedirectToAction("Index");
        }
        public IActionResult TrainingAddOefening(int id,string training_naam)
        {
            TrainingViewModel training = new TrainingViewModel();
            

            training.TrainingNaam = training_naam;
            training.Id = id;

            foreach (var item in trainingLogica.TrainingAddOefeningLogica(id, training_naam).Training_oefening)
            {
                Training_oefening NewItem = new Training_oefening();
                NewItem.set = item.set;
                NewItem.Oefening = new Oefening();
                NewItem.Oefening.oefening_naam = item.Oefening.Oefening_naam;
                NewItem.Oefening.id = item.Oefening.Id;

                training.TrainingOefening.Add(NewItem);
            }

            return View("TrainingAddOefening", training);
        }
        public IActionResult TrainingDetails(int id, string training_naam)
        {
            TrainingViewModel training = new TrainingViewModel();

            training.TrainingNaam = training_naam;
            training.Id = id;
            try
            {
            var items = trainingLogica.TrainingDetailsLogica(id, training_naam)?.Training_oefening;
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        Training_oefening NewItem = new Training_oefening();
                        NewItem.set = item.set;
                        NewItem.Oefening = new Oefening();
                        NewItem.Oefening.oefening_naam = item.Oefening.Oefening_naam;

                        training.TrainingOefening.Add(NewItem);
                    }
                }
                if (training == null)
                {
                    return RedirectToAction();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Controller Error: " + ex.Message);

                ViewBag.ErrorMessage = "Controller Error: " + ex.Message;
            }

            return View(training);
        }

        public IActionResult TrainingDelete(int id)
        {
            trainingLogica.TrainingDeleteLogica(id);
            return RedirectToAction("Index");
        }
        public IActionResult AddOefening(TrainingViewModel training)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.ErrorMessage = "Geen rare getallen gaan doen";
                return View("TrainingAddOefening", training);
            }
            trainingLogica.TrainingAddOefeningLogica(training.Id, training.ExerciseSelectedId, training.AmountOfSets);
            return RedirectToAction("Index");
        }



    }
}


    

