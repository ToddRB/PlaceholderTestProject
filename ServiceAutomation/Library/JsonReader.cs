using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Common.Library
{
    public static class JsonReader
    {
        public static string ReadJsonFromInputFile(string fileName)
        {
            var fullPath = GetCurrentJsonFilePath() + fileName;
            JObject jsonText = JObject.Parse(File.ReadAllText(GetCurrentJsonFilePath() + fileName));

            return jsonText.ToString();
        }

        private static string GetCurrentJsonFilePath()
        {
            var initialDirectory = Directory.GetCurrentDirectory();
            return initialDirectory + "\\JsonDataFiles\\";
        }
    }
}
