using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPACodingTest.Lib;
using CPACodingTest.Utility;

namespace CPACodingTest.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Part 1 ...");
            var requestHelper = new RequestHelper("https://cpacodingchallenge.azurewebsites.net/api/results");
            var dataManager = new ResultsDataManager(requestHelper);
            var resultsModel = dataManager.GetSubjectResultsModelAsync().Result;
            foreach (var result in resultsModel.Results)
            {
                System.Console.WriteLine();
                System.Console.WriteLine(result.Key);
                System.Console.WriteLine(new string('-', 80));
                foreach (var subject in result.Value)
                {
                    System.Console.WriteLine(subject);
                }
            }

            //Part 2
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Part 2 ...");
            var originalData = dataManager.GetSubjectResultsDataAsync().Result;
            foreach (var data in originalData)
            {
                System.Console.WriteLine();
                System.Console.WriteLine(data.Subject);
                System.Console.WriteLine(new string('-', 80));
                foreach (var result in data.Results)
                {
                    System.Console.WriteLine("Year " + result.Year);
                    System.Console.WriteLine("Grade " + result.Grade);
                }
            }

            System.Console.ReadKey();
        }
    }
}
