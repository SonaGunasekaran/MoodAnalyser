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
                if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException)
            {
                return "happy";
            }   
        }
   }
}
