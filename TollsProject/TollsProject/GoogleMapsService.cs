using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TollsProject
{
    class GoogleMapsService : GoogleService
    {
        private string actualURL;
        protected override GoogleService.APITypes apiType
        {
            get
            {
                return apiType;
            }
            set
            {
                apiType = APITypes.Directions;
            }
        }

        public GoogleMapsService()
        {
            actualURL = (baseURL = "maps");
        }

        public string Origin
        {
            get
            {
                return Origin;
            }
            set
            {
                Regex alphanumerics = new Regex(@"\d+");
                Match match = alphanumerics.Match(value);
                if (match.Success)
                {
                    this.Origin = value;
                }
                else
                {
                    throw new Exception("Invalid address");
                }
            }
        }

        public void Get()
        {
            // use this.Origin
            if (this.Origin != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(this.actualURL);
                // HttpResponseMessage response = client.GetAsync();
            }
        }

        override public void Get(string input)
        {
            // use input
        }
    }
}
