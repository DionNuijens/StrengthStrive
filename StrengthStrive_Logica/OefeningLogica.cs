using StrengthStrive_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrengthStrive_Logica
{
    public class OefeningLogica
    {
        public static List<OefeningModel> Oefeningen()
        {
            List<StrengthStrive_Logica.OefeningModel> oefeningen = new List<StrengthStrive_Logica.OefeningModel>();

            foreach (var item in OefeningDal.Silvan2())
            {
                StrengthStrive_Logica.OefeningModel newItem = new StrengthStrive_Logica.OefeningModel();
                newItem.id = item.id;
                newItem.oefening_naam = item.oefening_naam;

                oefeningen.Add(newItem);
            }

            return (oefeningen);
        }


    }
}
