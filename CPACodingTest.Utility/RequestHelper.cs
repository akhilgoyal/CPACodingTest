using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CPACodingTest.Utility
{
    /// <summary>
    /// A helper class that wraps CRUD operations against a remote REST api
    /// </summary>
    public class RequestHelper : IRequestHelper
    {
        private string RemoteUrl { get; }

        public RequestHelper(string remoteUrl)
        {
            RemoteUrl = remoteUrl;
        }

        public async Task<T> GetAsync<T>()
        {
            try
            {
                // Create a new client 
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var httpResponse = await client.GetAsync(RemoteUrl);
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();

                    // Do not set null value properties, keep their default values.
                    var jsonSettings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};

                    var result = JsonConvert.DeserializeObject<T>(responseContent, jsonSettings);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occurred when getting data from remote url {RemoteUrl} - {ex}");
            }
        }

        //public Task PostAsync<T>(T data)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task PutAsync<T>(T data)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteAsync<T>()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
