using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrengthStrive_Logic
{
    public class OefeningModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Oefening_naam { get; set; }
    }
}
