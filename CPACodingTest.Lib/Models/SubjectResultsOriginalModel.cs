using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPACodingTest.DomainEntities;

namespace CPACodingTest.Lib.Models
{
    public class SubjectResultsOriginalModel
    {
        public SubjectResultsOriginalModel()
        {
            Results = new List<Result>();
        }

        public string Subject { get; set; }
        public List<Result> Results { get; set; }
    }
}
