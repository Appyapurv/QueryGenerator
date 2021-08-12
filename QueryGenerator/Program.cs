using Newtonsoft.Json;
using QueryGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Read file
            string inputJson = FileProcess.ReadFile("RawQueryInput.json");
            var inputModel = JsonConvert.DeserializeObject<Table>(inputJson);
            var query = new QueryGenerator();
            var generatedQuery = query.GenerateQuery(inputModel,"*");
            Console.WriteLine("*************************Query With Operators*************");
            Console.WriteLine(generatedQuery);
            var subQuery = query.GenerateSubQueryQuery(inputModel);
            Console.WriteLine("*************************SubQuery Query*************");
            Console.WriteLine(subQuery);
            //Console.ReadLine();

            // Read Join Query
            string inputJoinJson = FileProcess.ReadFile("RawQueryWithJoins.json");
            var inputJoinModel = JsonConvert.DeserializeObject<TableJoin>(inputJoinJson);
            var generatedJoinQuery = query.GenerateJoinQuery(inputJoinModel);
            Console.WriteLine("*************************Query With Operators and Joins*************");
            Console.WriteLine(generatedJoinQuery);
            Console.ReadLine();

            
        }

        
    }
}
