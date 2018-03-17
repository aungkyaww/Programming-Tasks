using Newtonsoft.Json;
using System;
using System.IO;

namespace MusicRepoAndPlayer
{
    static class JSONSerialisation
    {
        // public static string defaultPath = Environment.ExpandEnvironmentVariables(@"C:\Users\%USERPROFILE%\Documents\Music\music.txt");
        public static string DefaultPath
        {
            get
            {
                return Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Documents\Music\music.txt");
            }
        }

        public static void WriteToFile<T>(T objectToWrite, string path, bool append = false)
        {
            TextWriter textWriter = null;
            string serialisedObject = JsonConvert.SerializeObject(objectToWrite);
            

            using (textWriter = new StreamWriter(path, append))
            {
                try
                {
                    textWriter.Write(serialisedObject);
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public static T ReadFromFile<T>(string path) where T : new() //Limits T to an instance class.
        {
            TextReader textReader = null;
            if (File.Exists(path))
            {
                using (textReader = new StreamReader(path))
                {
                    try
                    {
                        string fileContents = textReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<T>(fileContents);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            }
            return default(T);


        }

    }
}
