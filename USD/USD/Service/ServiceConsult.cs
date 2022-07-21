#region References
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using USD.Models;
using static USD.Models.Request; 
#endregion

namespace USD.Service
{
    public class ServiceConsult : IServiceConsult
    {
        private readonly IConfiguration _configuration;
        public ServiceConsult(IConfiguration configuration) =>  _configuration = configuration;
     
        public async Task<Root> Get()
        {
            HttpClient client = new();
            var httpResponse = await client.GetAsync(_configuration["Uri:UriServices"]);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var a = httpResponse.IsSuccessStatusCode.ToString();
                var b = httpResponse.RequestMessage;
                throw new Exception($"message:{b} error: {a}");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var request = JsonConvert.DeserializeObject<Root>(content);
            return request;
        }
    }
}
