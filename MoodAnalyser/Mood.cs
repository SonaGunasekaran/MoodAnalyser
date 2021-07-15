using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
   public class Mood
    {
        string message;
        public Mood(string msg)
        {
            this.message = msg;
        }

        public string CheckMood()
        {
            if (this.message.ToLower().Contains("happy"))
            {
                return "happy";
            }
            else
            {
                return "sad";
            }
        }
    }
}
