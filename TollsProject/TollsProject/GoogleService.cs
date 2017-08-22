using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TollsProject
{
    abstract class GoogleService
    {
        abstract protected APITypes apiType { get; set; }
        protected const string outputFormat = "JSON";
        protected const string key = "AIzaSyBROdaynkU9wc15ztvINhJubWgZ-05nJxU";
        protected string baseURL = "https://{0}.googleapis.com/{0}/api/";

        abstract public void Get();
        abstract public void Get(string input);

        [Flags]
        public enum APITypes
        {
            Directions,
            Elevation,
            Places
        }
    }
}
