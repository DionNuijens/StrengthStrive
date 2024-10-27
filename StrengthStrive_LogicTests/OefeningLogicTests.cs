using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrengthStrive_Logic;
using StrengthStriveDTO;
using System.Collections.Generic;

namespace StrengthStrive_Logic.Tests
{
    [TestClass]
    public class OefeningLogicTests
    {
        private class FakeOefeningDal :IOefeningDal
        {
            public List<OefeningDTO> GetAllOefeningenDal()
            {
                return new List<OefeningDTO>
                {
                    new OefeningDTO { id = 1, oefening_naam = "Oefening1" },
                    new OefeningDTO { id = 2, oefening_naam = "Oefening2" },
                };
            }

            public void OefeningAddDal(string oefening_naam)
            {
            }

            public void OefeningChangedDal(int id, string oefening_naam)
            {
            }

            public void OefeningDeleteDal(int id)
            {
            }

        }

        [TestMethod]
        public void GetAllOefeningenLogicTest()
        {
            // Arrange
            var fakeOefeningDal = new FakeOefeningDal();
            var oefeningLogic = new OefeningLogic(fakeOefeningDal);

            // Act
            var result = oefeningLogic.GetAllOefeningenLogic();
             
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); 
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual("Oefening1", result[0].Oefening_naam);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual("Oefening2", result[1].Oefening_naam);
        }
    }
}