using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MoodAnalyser
{
   public class MoodAnalyserFactory
   {
        public static object CreateObjectForMoodAnalyser(string className, string constructorName)
        {
            //check whether constructor name and class name are equal
            string pattern = @"." + constructorName + "";
            Match result = Regex.Match(className, pattern);
            //if equal then create the object
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                //if class is not found then it throws class not found exception
                catch (ArgumentNullException)
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            //if class and constructor name is not equal then it throws constructor not found exception
            else
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }

        }
    }
}
