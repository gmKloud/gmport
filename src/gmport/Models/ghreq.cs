using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NuGet.Protocol.Core.v3;

namespace gmport.Models
{
    public class ghreq
    {
        public string Name { get; set; }

        public static JArray GetRepos()
        {

            var client = new RestClient("https://api.github.com");

            ////created HTTP Content to be posted
            var request = new RestRequest("/users/gmkhanna/starred", Method.GET);

            request.AddHeader("Accept", "application / vnd.github.v3 + json");
            request.AddHeader("User-Agent", "gmkhanna");

            //request.AddHeader(EnvironmentVariables.user, EnvironmentVariables.authToken);

            //client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.userName, EnvironmentVariables.password);

            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            //var response = client.ExecuteAsync<List<ghreq>>(request);

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);

            return jsonResponse;
            

            ////Get Response
            //HttpResponseMessage response = await client.PostAsync(https://api.github.com, request);

            ////Get Response Content- //
            //HttpContent responseContent = response.Content;

            //HEADER Version
            //WebRequest request = WebRequest.Create(url);
            //request.Method = "GET";

            //request.Headers.Add("Authorization: token" + EnvironmentVariables.authToken);

        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient reqClient, RestRequest querriedReq)
        {
            var compl = new TaskCompletionSource<IRestResponse>();
            reqClient.ExecuteAsync(querriedReq, ResponseStatus =>
            {
                compl.SetResult(ResponseStatus);
            });
            return compl.Task;
        }
    }
}
