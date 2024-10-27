using StrengthStrive_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrengthStrive_Logic
{
    public class Training_oefeningModel
    {

        public OefeningModel Oefening { get; set; }
        public int set { get; set; }

        public Training_oefeningModel()
        {
            Oefening= new OefeningModel();
        }
    }
}
