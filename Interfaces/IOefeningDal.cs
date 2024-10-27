using StrengthStrive_DAL;
using StrengthStriveDTO;

namespace Interfaces
{
    public interface IOefeningDal
    {
        List<OefeningDTO> GetAllOefeningenDal();
        void OefeningAddDal(string oefening_naam);
        void OefeningChangedDal(int id, string oefening_naam);
        void OefeningDeleteDal(int id);
    }
}