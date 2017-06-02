using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Domain_Models;
using RestSharp;
using System.Net;
using System.Configuration;

namespace DataAccessLayer.Classes
{
    public class GetPetsJson : IGetPetsJson
    {
        private IRestClient client;
        private readonly string BaseUri = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly string Uri = ConfigurationManager.AppSettings["Url"];
        public GetPetsJson(IRestClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException();
            }
            this.client = client;
        }

        public List<PetJson> getJsonData()
        {
            List<PetJson> jsondata = new List<PetJson>();
            IRestRequest request;

            try
            {
                client.BaseUrl = new Uri(BaseUri);
                request = new RestRequest(Uri, Method.GET);
                var restResponse = client.Execute<List<PetJson>>(request);


                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    jsondata = restResponse.Data;
                }
                else
                {
                    throw new Exception("Error ocuured" + restResponse.StatusCode);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return jsondata;
        }
    }
}