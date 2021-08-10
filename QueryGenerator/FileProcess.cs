using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator
{
    public class FileProcess
    {
        public static string ReadFile(string fileName)
        {
            var fileDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = $"//{fileName}";
            var inputJson = File.ReadAllText(fileDirectory + filePath);
            return inputJson;
        }
    }
}
