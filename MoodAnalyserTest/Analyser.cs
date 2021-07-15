using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    [TestClass]
    public class Analyser
    {
        Mood mah,mas,mahNull;
        string msg;
        [TestInitialize]
        public void Setup()
        {
            this.msg = "Happy Mood";
            mah = new Mood(this.msg);
            mas = new Mood("Sad mood");
            mahNull = new Mood(null);
        }
        [TestMethod]
        [TestCategory("happy")]
        public void Happy()
        {
            //Arrange
            string actual, expected = "happy";
            //Act
            actual = mah.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("sad")]
        public void Sad()
        {
            //Arrange
            string actual, expected = "sad";
            //Act
            actual = mas.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("null")]
        public void Null()
        {
            //Arrange
            string actual, expected = "happy";
            //Act
            actual = mahNull.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
