using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrengthStrive_DAL
{
    public class TrainingDTO
    {
        public int id { get; set; }
        public string training_naam { get; set; }

        public List<Training_oefeningDTO> Training_oefening { get; set; }

    }
}
