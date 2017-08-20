using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TollsProject
{
    class GoogleMapsService : GoogleService
    {
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
            baseURL = "maps";
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

        override public void Get()
        {
            // use this.Origin
        }

        public static void Get(string input)
        {
            // use input
        }
    }
}
