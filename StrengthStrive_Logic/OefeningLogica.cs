using Interfaces;
using StrengthStrive_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StrengthStrive_Logic
{
    public class OefeningLogic 
    {
        private readonly IOefeningDal _oefening;

        public OefeningLogic(IOefeningDal oefening) { 

            _oefening = oefening;
        }

        public List<OefeningModel> GetAllOefeningenLogic()
        {
            List<OefeningModel> oefeningen = new List<OefeningModel>();

            try
            {
                foreach (var item in _oefening.GetAllOefeningenDal())
                {
                    OefeningModel newItem = new OefeningModel();
                    newItem.Id = item.id;
                    newItem.Oefening_naam = item.oefening_naam;
                    oefeningen.Add(newItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("BLL Error: " + ex.Message);

                throw;
            }

            return oefeningen;
        }

        public void OefeningAddLogica(string oefening_naam)
        {

            _oefening.OefeningAddDal(oefening_naam);
        }

        public void OefeningChangedLogica(int id, string oefening_naam)
        {
            try
            {
            _oefening.OefeningChangedDal(id, oefening_naam);

            }
            catch (Exception ex)
            {
                Console.WriteLine("BLL Error: " + ex.Message);

                throw;
            }
        }

        public void OefeningDeleteLogica(int id)
        {
            _oefening.OefeningDeleteDal(id);
        }
    }
}
