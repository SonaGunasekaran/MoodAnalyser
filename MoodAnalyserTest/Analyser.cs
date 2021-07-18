using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System.Reflection;

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
        [TestMethod]
        public void MoodAnalyserReflection()
        {
            object expected = new Mood();
            object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyser("MoodAnalyzer.MoodAnalyze", "MoodAnalyze");
            expected.Equals(actual);
        }
        [TestMethod]
        public void MoodAnalyserobjectReflection()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyser("MoodAnalyzer.MoodAnalyzer", "MoodAnalyzer");
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void MoodAnalyserObjectReflection1()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyser("MoodAnalyzer.MoodAnalyze", "MoodAnalyzer");
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void ObjectParameterizedConstructor()
        {
            object expected = new Mood("Happy");
            object actual = MoodAnalyserFactory.ParameterizedConstructor("MoodAnalyzer.MoodAnalyze", "MoodAnalyze", "Happy");
            expected.Equals(actual);
        }
        [TestMethod]
        public void ObjectParameterizedConstructor1()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyserFactory.ParameterizedConstructor("MoodAnalyzer.MoodAnalyzer", "MoodAnalyzer", "Happy");
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void ObjectParameterizedConstructor2()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyserFactory.ParameterizedConstructor("MoodAnalyzer.MoodAnalyze", "MoodAnalyzer", "I am happy");
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void InvokeReflection()
        {
            string expected = "Happy";
            string actual = MoodAnalyserFactory.ChangeMood("i am happy", "AnalyseMood");
            expected.Equals(actual);
        }
        [TestMethod]
        public void InvokeReflection1()
        {
            string expected = "Method not found";
            try
            {
                string actual = MoodAnalyserFactory.ChangeMood("Happy", "AnalyserMood");
                expected.Equals(actual);
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
        [TestMethod]
        public void ChangeMoodReflection()
        {
            string expected = "Happy";
            string actual = MoodAnalyserFactory.SetField("Happy", "message");
            expected.Equals(actual);
        }
        [TestMethod]
        public void ChangeMoodReflection1()
        {
            string expected = "Field is not found";
            try
            {
                string actual = MoodAnalyserFactory.SetField("Happy", "message");
                expected.Equals(actual);
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void ChangeMoodReflection2()
        {
            string expected = "Message should not be null";
            try
            {
                string actual = MoodAnalyserFactory.SetField(null, "message");
                expected.Equals(actual);
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

    }
}
