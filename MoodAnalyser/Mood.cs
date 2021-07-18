using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class Mood
    {
        string message;
        //default constructor
        public Mood()
        {
            Console.WriteLine("Default Constructor");
        }
        public Mood(string message)
        {
            this.message = message;
        }
        public string CheckMood()
        {
            try
            {
                message = message.ToLower();
                //check if message is empty or not
                if (message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");

                }
                //check whether the message is equal to null
                if (message.Equals(null))
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Mood should not be null");
                }
                if (message.Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException ex)
            {
                return "happy";
            }
        }
    }
}
