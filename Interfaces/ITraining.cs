using StrengthStrive_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITraining
    {
        List<TrainingDTO> GetAll();
        void TrainingCreateDal(string training_naam);
        void DeleteBy(int id);
        void AddOefeningDal(int id, int oefeningId, int sets);
        TrainingDTO TrainingDetailsDal(int id, string training_naam);
    }
}
