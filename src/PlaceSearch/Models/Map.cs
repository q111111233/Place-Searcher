using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaceSearch.Models
{
    public class Map
    {
        public string Start_address { get; set; }
        public string End_address { get; set; }
        public string Distance { get; set; }
        public static string GetMaps(string Start_address, string End_address)
        {

            var client = new RestClient("https://maps.googleapis.com/maps/api");
            var request = new RestRequest("directions/json?origin=" + Start_address + "&destination=" + End_address + "&avoid=highways&mode=bicycling&key=AIzaSyCLEaa7mRHy5jEfRpW9rhRTZkLtJNZZ3B0", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            
            var routes = JsonConvert.DeserializeObject<List<Map>>(jsonResponse["routes"].ToString());
            
            return jsonResponse["routes"][0]["legs"][0]["distance"]["text"].ToString();
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
