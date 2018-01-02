using System;
using System.Collections.Generic;
using System.Text;
using CPACodingTest.DomainEntities;

namespace CPACodingTest.Lib.Models
{
    public class SubjectResultsModel
    {
        public SubjectResultsModel()
        {
            Results = new SortedList<string, List<string>>();
        }
        public String Subject { get; set; }
        public SortedList<string, List<string>> Results { get; set; }

    }
}
