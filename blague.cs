using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bot_CNAM
{
    class blague
    {
        string token = "-bkmg.g40IyQA0n6r1ZMJl-GVKPjMX5A.G.O5h2Tgj9Uc_1kugPOWWE7fbS_iAz_";
        private JObject requeteapi(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("authorization", token);
            using (System.IO.Stream s = request.GetResponse().GetResponseStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                {
                    var jsonResponse = sr.ReadToEnd();
                    return JObject.Parse(jsonResponse);
                }
            }
        }

        public string joke()
        {
            JObject obj = requeteapi("https://blague.xyz/api/joke/random");
            JToken tok = obj.SelectToken("joke");
            return "```" + tok["question"] + "\n\n" + tok["answer"] + "```";
        }
        public string vdm()
        {
            JObject obj = requeteapi("https://blague.xyz/api/vdm/random");
            JToken tok = obj.SelectToken("vdm");
            return "```" + tok["content"].ToString() + "```";
        }
    }
}