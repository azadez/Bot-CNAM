using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Web;
using System.Net;
using System.IO;
using RestSharp;

namespace Bot_CNAM
{
    class edt
    {
        string url = "http://qrc.gescicca.net/Planning.aspx?id=mmw7MgOktQ%2bcNzdLFCBR0g%3d%3d&annsco=2020&typepersonne=AUDITEUR";
        public edt()
        {

        }

        private string GetReq(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "6aef6e79-9eef-5e6b-043b-0bbd4da3380e");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        private string PostReq(string url, string state)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "6aef6e79-9eef-5e6b-043b-0bbd4da3380e");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"__VIEWSTATE\"\r\n\r\n" + state + "\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"__VIEWSTATEGENERATOR\"\r\n\r\nD809D6B1\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"ctl00$MainContent$btnNavNext.x\"\r\n\r\n10\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"ctl00$MainContent$btnNavNext.y\"\r\n\r\n10\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
            var response = client.Execute(request);
            return response.Content;
        }

        private string SearchState(string content)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(content);
            var viewstate = htmlDocument.DocumentNode.Descendants("input")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("__VIEWSTATE")).ToList();
            return viewstate[0].GetAttributeValue("value", "");
        }
        public async Task<string> Getedt(bool B)
        {
            var content = GetReq(url);

            if (B)
            {
                content = PostReq(url, SearchState(content));
            }
            
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(content);


            var InfoList = htmlDocument.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("ctl00_MainContent_rptr")
                && !node.InnerText.Equals("")).ToList();

            var MatiereList = htmlDocument.DocumentNode.Descendants("a")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("ctl00_MainContent_rptr")).ToList();

            return Concat(InfoList, MatiereList);
        }

        private string Concat(List<HtmlNode> l1, List<HtmlNode> l2)
        {
            var value = new[] { "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi", "dimanche" };
            StringBuilder str = new StringBuilder();
            str.Append("```");
            int x = 0;
            int y = 0;
            while (x < l1.Count())
            {
                if (value.Any(l1[x].InnerText.Contains))
                {
                    str.AppendLine("");
                    str.AppendLine($"{l1[x].InnerText}");

                    x++;
                }
                else
                {
                    if (l1[x + 1].InnerText.Equals("Examen"))
                    {
                        str.AppendLine($"{l1[x].InnerText,-15} Examen   {cours(l2[y].InnerText),-50} {l1[x + 2].InnerText}");
                        x += 3;
                        y++;
                    }
                    else
                    {
                        str.AppendLine($"{l1[x].InnerText,-24} {cours(l2[y].InnerText),-50} {l1[x + 2].InnerText}");
                        x += 3;
                        y++;
                    }
                }
            }
            str.Append("```");
            return str.ToString();
        }
        private static string cours(string str)
        {
            switch (str)
            {
                case "SLOFIP":
                    return "Enseignements en Slovaquie";
                case "UASI02":
                    return "Expérience d'apprentissage";
                case "USSI0P":
                    return "Administration de bases de données";
                case "USSI0Q":
                    return "Business Intelligence";
                case "USSI0R":
                    return "Apprentissage et Intelligence artificielle";
                case "USSI0S":
                    return "Systèmes d'informations Web";
                case "USSI0T":
                    return "Génie logiciel";
                case "USSI0U":
                    return "Gestion de projet : méthodes et outils";
                case "USSI0V":
                    return "Méthodologie avancée";
                case "USSI0W":
                    return "Systèmes d'exploitation avancés et Virtualisation";
                case "USSI0X":
                    return "Sécurité et réseaux";
                case "USSI0Y":
                    return "Algorithmes pour le Cloud Computing";
                case "USSI10":
                    return "Test et validation";
                case "USSI11":
                    return "Recherche opérationnelle";
                case "USSI12":
                    return "Structures et Organisation de l'entreprise";
                case "USSI13":
                    return "Droit commercial";
                case "USSI14":
                    return "Finance d'entreprise et comptabilité de gestion";
                case "USSI15":
                    return "Situation de communication internationale";
                case "USSI16":
                    return "Communication en situation professionnelle";
                case "USSI17":
                    return "Gestion d'un service informatique";
                case "USSI18":
                    return "Conduite du changement";
                case "USSI19":
                    return "Logistique et supply chain";
                case "USSI1A":
                    return "Création d'entreprise";
                case "USSI1T":
                    return "Développement mobile";
                case "USSI1U":
                    return "Management";
                default:
                    return "erreur";
            }
        }
    }
}
