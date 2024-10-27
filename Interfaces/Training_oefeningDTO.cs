using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrengthStriveDTO;

namespace StrengthStrive_DAL
{
    public class Training_oefeningDTO
    {
        public int training_id { get; set; }
        public TrainingDTO Training { get; set; }
        public int oefening_id { get; set; }
        public OefeningDTO Oefening { get; set; }

        [Required]
        [MinLength(1)]
        public int set { get; set; }

    }
}
