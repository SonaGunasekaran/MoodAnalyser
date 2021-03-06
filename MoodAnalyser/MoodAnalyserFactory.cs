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
        public static object ParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = Type.GetType(className);
            try
            {
                if (type.FullName.Equals(className) || type.Name.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                        object instance = info.Invoke(new object[] { message });
                        return instance;
                    }
                    //if class and constructor name is not equal then it throws constructor not found exception
                    else
                    {
                        throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
                    }

                }
                //if class is not found then it throws class not found exception
                else
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
        public static string ChangeMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzer.MoodAnalyze");
                object moodAnalyseObject = MoodAnalyserFactory.ParameterizedConstructor("MoodAnalyzer.MoodAnalyze", "MoodAnalyze", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            //if method is not found then it throws method not found exception
            catch (NullReferenceException ex)
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_METHOD_FOUND, "Method not found");
            }
        }
        public static string SetField(string message, string fieldName)
        {
            try
            {
                Mood mood = new Mood();
                Type type = typeof(Mood);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Message should not be null");
                }
                fieldInfo.SetValue(mood, message);
                return mood.message;
            }
            //if field is not found then it throws field not found exception
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_FEILD_EXIST, "Field is not found");
            }
        }
    }
}
