using StrengthStrive_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrengthStrive_Logic
{
    public class TrainingModel
    {
        public int id { get; set; }
        public string training_naam { get; set; }
        public List<Training_oefeningModel> Training_oefening { get; set; }

        public TrainingModel()
        {
            Training_oefening = new List<Training_oefeningModel>();
        }
    }
}
