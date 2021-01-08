using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace Bot_CNAM
{
    class edt
    {
        public edt()
        {

        }
        public async Task<string> Getedt()
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync("http://qrc.gescicca.net/Planning.aspx?id=mmw7MgOktQ%2bcNzdLFCBR0g%3d%3d&annsco=2020&typepersonne=AUDITEUR");

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var InfoList = htmlDocument.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("ctl00_MainContent_rptr")
                && !node.InnerText.Equals("")).ToList();

            var MatiereList = htmlDocument.DocumentNode.Descendants("a")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("ctl00_MainContent_rptr")).ToList();

            var value = new[] { "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi", "dimanche" };
            StringBuilder str = new StringBuilder();
            str.Append("```");
            int x = 0;
            int y = 0;
            while (x < InfoList.Count())
            {
                if (value.Any(InfoList[x].InnerText.Contains))
                {
                    str.AppendLine("");
                    str.AppendLine($"{InfoList[x].InnerText}");

                    x++;
                }
                else
                {
                    if (InfoList[x + 1].InnerText.Equals("Examen"))
                    {
                        str.AppendLine($"{InfoList[x].InnerText,-15} Examen   {cours(MatiereList[y].InnerText),-50} {InfoList[x + 2].InnerText}");
                        x += 3;
                        y++;
                    }
                    else
                    {
                        str.AppendLine($"{InfoList[x].InnerText,-24} {cours(MatiereList[y].InnerText),-50} {InfoList[x + 2].InnerText}");
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
