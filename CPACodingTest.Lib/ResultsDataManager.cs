using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPACodingTest.DomainEntities;
using CPACodingTest.Lib.Models;
using CPACodingTest.Utility;

namespace CPACodingTest.Lib
{
    /// <summary>
    /// Uses a request helper to load and process pet data from a remote source.
    /// </summary>
    public class ResultsDataManager
    {
        private IRequestHelper RequestHelper { get; }

        public ResultsDataManager(IRequestHelper requestHelper)
        {
            RequestHelper = requestHelper;
        }

        public async Task<List<SubjectResults>> GetSubjectResultsDataAsync()
        {
            return await RequestHelper.GetAsync<List<SubjectResults>>();
        }

        public async Task<SubjectResultsModel> GetSubjectResultsModelAsync()
        {
            var subjectResults = await GetSubjectResultsDataAsync();
            var result = new SubjectResultsModel();
            foreach (var subjectResult in subjectResults)
            {
                if (subjectResult.Results.Any(x => x.Grade.Equals("PASS")))
                {
                    string subject = subjectResult.Subject;
                    string passYear = subjectResult.Results.First(x => x.Grade.Equals("PASS")).Year;

                    if (result.Results.ContainsKey(passYear))
                    {
                        List<string> results = null;
                        result.Results.TryGetValue(passYear, out results);
                        if (results != null)
                        {
                            results.Add(subject);
                            result.Results[passYear] = results;
                        }
                    }
                    else
                    {
                        result.Results.Add(passYear, new List<string> { subject });
                    }
                }
            }
            foreach (var resultResult in result.Results)
            {
                resultResult.Value.Sort();
            }
            return result;
        }

        //public async Task<List<SubjectResultsOriginalModel>> GetSubjectResultsOriginalModelAsync()
        //{
        //    var subjectResults = await GetSubjectResultsDataAsync();

        //    var resultList = new List<SubjectResultsOriginalModel>();
        //    foreach (var subjectResult in subjectResults)
        //    {
        //        var subjectResultsOriginal = new SubjectResultsOriginalModel();
        //        subjectResultsOriginal.Subject = subjectResult.Subject;
        //        foreach (var result in subjectResult.Results)
        //        {
        //            subjectResultsOriginal.Results.Add(result);
        //        }
        //        resultList.Add(subjectResultsOriginal);
        //    }
        //    return resultList;
        //}
    }
}
