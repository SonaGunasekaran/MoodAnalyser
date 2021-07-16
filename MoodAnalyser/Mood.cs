using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class Mood
    {
        string message;
        public Mood(string message)
        {
            this.message = message;
        }

        public string CheckMood()
        {
            try
            {
                message = message.ToLower();
                if (message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");

                }
                if (message.Equals(null))
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.NULL_EXCEPTION, "Mood should not be null");
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
            catch (NullReferenceException e)
            {
                return "happy";
            }
        }
    }
}
