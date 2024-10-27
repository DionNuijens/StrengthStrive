using StrengthStrive_Logic;
using System.ComponentModel.DataAnnotations;

namespace StrengthStrive.Models
{
    public class TrainingViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string TrainingNaam { get; set; }
        public List<Training_oefening> TrainingOefening { get; set; }

        public int ExerciseSelectedId { get; set; }

        [Required]
        [Range(1,100)]
        public int AmountOfSets { get; set; }

        public TrainingViewModel()
        {
            TrainingOefening = new List<Training_oefening>();
        }
    }
}
