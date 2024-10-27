using Interfaces;
using Microsoft.AspNetCore.Mvc;
using StrengthStrive.Models;
using StrengthStrive_DAL;
using StrengthStrive_Logic;
using Microsoft.Extensions.Configuration;


namespace StrengthStrive.Controllers
{

    public class OefeningController : Controller
    {
        private readonly OefeningLogic oefeningLogic;
        private readonly string _connectionString;

        public OefeningController(OefeningLogic oefeningLogic, IConfiguration configuration)
        {
            this.oefeningLogic = oefeningLogic;
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?"); //haalt de connection string uit de appsettings, geeft het geen string mee, dan gooit het een exception
        }

        public IActionResult Index()
        {
            List<Oefening> oefeningen = new List<Oefening>();

            try
            {
                foreach (var item in oefeningLogic.GetAllOefeningenLogic())
                {
                    Oefening newItem = new Oefening();
                    newItem.id = item.Id;
                    newItem.oefening_naam = item.Oefening_naam;
                    oefeningen.Add(newItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Controller Error: " + ex.Message);

                ViewBag.ErrorMessage = "Controller Error: " + ex.Message;
            }

            return View(oefeningen);
        }

        public IActionResult OefeningCreate() 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View(); 
        }

        public IActionResult OefeningAdd(string oefening_naam)
        {
            foreach (var item in oefeningLogic.GetAllOefeningenLogic())
            {
               if(oefening_naam == item.Oefening_naam)
                {
                    ViewBag.ErrorMessage = "Deze bestaat al oelewapper";
                    return View("OefeningCreate");
                }
            }
            if(!ModelState.IsValid)
            {
                return View("OefeningCreate");
            }
            oefeningLogic.OefeningAddLogica(oefening_naam);
            return RedirectToAction("Index");
        }

        public IActionResult OefeningEdit(int id, string oefening_naam)
        {
            return View();
        }

        public IActionResult OefeningChanged(int id, string oefening_naam)
        {
            try
            {
            foreach (var item in oefeningLogic.GetAllOefeningenLogic())
            {
                if (oefening_naam == item.Oefening_naam)
                {
                    ViewBag.ErrorMessage = "Deze bestaat al oelewapper";
                    return View("OefeningEdit");
                }
            }
            oefeningLogic.OefeningChangedLogica(id, oefening_naam);


                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Controller Error: " + ex.Message);

                ViewBag.ErrorMessage = "Controller Error: " + ex.Message;
                return View("OefeningEdit");
            }
        }

        public IActionResult OefeningDelete(int id)
        {

            oefeningLogic.OefeningDeleteLogica(id);
            return RedirectToAction("Index");
        }
    }
}
