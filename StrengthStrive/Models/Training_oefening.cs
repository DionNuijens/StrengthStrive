using StrengthStrive_Logic;

namespace StrengthStrive.Models
{
    public class Training_oefening
    {
        public Oefening Oefening { get; set; }
        public int set {  get; set; }

        public Training_oefening()
        {
            Oefening = new Oefening();
        }
    }
}
