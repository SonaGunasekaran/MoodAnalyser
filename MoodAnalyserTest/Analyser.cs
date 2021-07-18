using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    [TestClass]
    public class Analyser
    {
        string msg;
        [TestMethod]
        [TestCategory("happy")]
        public void Happy()
        {
            //Arrange
            string actual, expected = "happy";
            string message = "I am in happy mood";
            //Act
            actual = new Mood(message).CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("sad")]
        public void Sad()
        {
            //Arrange
            string actual, expected = "sad";
            string message = "I am in sad mood";
            //Act
            actual = new Mood(message).CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("null")]
        public void Null()
        {
            //Arrange
            string actual, expected = "happy";
            string message = null;
            //Act
             actual = new Mood(message).CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CustomException()
        {
            string expected = "Mood should not be empty";
            try
            {
                string message = "";
                //act
                string actual = new Mood(message).CheckMood();
            }
            catch (CustomMoodAnalyserException ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }

        }
        [TestMethod]
        public void ShouldNotBeNull()
        {
            string expected = "Mood should not be null";
            try
            {
                string message = null;
                //act
                string actual = new Mood(message).CheckMood();
            }
            catch (CustomMoodAnalyserException ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }

        }
    }
}
