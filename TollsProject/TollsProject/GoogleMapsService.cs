using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TollsProject
{
    class GoogleMapsService : GoogleService
    {
        private string actualURL;
        private const string APIPath = "maps";
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
            actualURL = string.Format(baseURL + "directions/json?origin={0}&destination={1}", APIPath);
        }

        public string _origin;
        public string Origin
        {
            get
            {
                return this._origin;
            }
            set
            {
                Regex alphanumerics = new Regex(@"\d+");
                Match match = alphanumerics.Match(value);
                if (match.Success)
                {
                    this._origin = value;
                }
                else
                {
                    throw new Exception("Invalid from address");
                }
            }
        }
        public string _destination;
        public string Destination
        {
            get
            {
                return this._destination;
            }
            set
            {
                Regex alphanumerics = new Regex(@"\d+");
                Match match = alphanumerics.Match(value);
                if (match.Success)
                {
                    this._destination = value;
                }
                else
                {
                    throw new Exception("Invalid to address");
                }
            }
        }

        override public void Get()
        {
            // use this.Origin
            if (this.Origin != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(string.Format(this.actualURL, Origin, Destination));

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(client.BaseAddress);
                request.Method = "GET";
                string test = string.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }
        }

        override public void Get(string input)
        {
            // use input
        }
    }
}
