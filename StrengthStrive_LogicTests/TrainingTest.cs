using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrengthStrive_DAL;
using StrengthStrive_Logic;
using StrengthStriveDTO;
using System.Collections.Generic;

namespace StrengthStrive_Logic.Tests
{
    [TestClass]
    public class TrainingLogicaTests
    {
        private class FakeTraining : ITraining
        {
            private readonly List<TrainingDTO> trainings;

            public FakeTraining(List<TrainingDTO> trainings)
            {
                this.trainings = trainings;
            }

            public List<TrainingDTO> GetAll()
            {
                return trainings;
            }

            public void TrainingCreateDal(string training_naam)
            {
            }

            public void DeleteBy(int id)
            {
            }

            public void AddOefeningDal(int id, int oefeningId, int sets)
            {
            }

            public TrainingDTO TrainingDetailsDal(int id, string training_naam)
            {
                return null;
            }
        }

        [TestMethod]
        public void TrainingAddOefeningLogica_ShouldReturnTrainingModelWithOefeningen()
        {
            var fakeTraining = new FakeTraining(new List<TrainingDTO>());
            var oefeningDal = new OefeningDal("dummyString"); 
            var trainingLogica = new TrainingLogica(fakeTraining, oefeningDal);

            var result = trainingLogica.TrainingAddOefeningLogica(1, "TrainingNaam");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TrainingDetailsLogica_ShouldReturnTrainingModelWithTrainingOefening()
        {
            var fakeTraining = new FakeTraining(new List<TrainingDTO>());
            var oefeningDal = new OefeningDal("dummyString"); 
            var trainingLogica = new TrainingLogica(fakeTraining, oefeningDal);

            var result = trainingLogica.TrainingDetailsLogica(1, "TrainingNaam");

            Assert.IsNotNull(result);
        }
    }
}
