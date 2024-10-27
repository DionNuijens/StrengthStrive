using System.ComponentModel.DataAnnotations;

namespace StrengthStrive.Models
{
    public class Oefening
    {
        public int id { get; set; }

        [MaxLength(20)]
        public string oefening_naam { get; set; }
    }
}
