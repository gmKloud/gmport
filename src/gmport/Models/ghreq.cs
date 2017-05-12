using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;

namespace gmport.Models
{
    public class ghreq
    {
        public string Name { get; set; }

        public static List<ghreq> GetRepos()
        {

            var client = new RestClient("https://api.github.com");

            ////created HTTP Content to be posted
            var request = new RestRequest("?access_token=" + EnvironmentVariables.authToken + ".json", Method.GET);

            //client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.clientID, EnvironmentVariables.clientSecret); //// if password needed.

            var response = new RestResponse();

            //Task.Run(async () =>
            //{
            //    response = await GetResponseContentAsync(client, request) as RestResponse;
            //}).Wait();


            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<ghreq>>(jsonResponse["repos"].ToString());

            return repoList;
            

            ////Get Response
            //HttpResponseMessage response = await client.PostAsync(https://api.github.com, request);

            ////Get Response Content- //
            //HttpContent responseContent = response.Content;

            //HEADER Version
            //WebRequest request = WebRequest.Create(url);
            //request.Method = "GET";

            //request.Headers.Add("Authorization: token" + EnvironmentVariables.authToken);

        }
    }
}
