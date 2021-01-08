using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_CNAM
{
    class quote
    {
        Random rnd = new Random();
        public quote()
        {
           
        }
        public string rand()
        {
            string[] tab = new string[] { "Ma boulangère elle ressemble à rien, elle fait 200 kilos, elle est plus large que haute, elle est disgracieuse; mais elle fait du bon pain!",
"Plus c'est gros, plus c'est facile à avaler",
"Moi j'tire un coup, ça va pas plus loin que 2m la balle elle retombe tout de suite",
"Just do it à la con",
"pour que vous soyez culturés",
"Si vous pétez chez les autres et que ça sent mauvais, c'est votre problème",
"Moi j'ai rien contre les pd",
"Mon savoir est un peu grand",
"Les hommes peuvent sortir leur bistouquette du pantalon",
" Le goût pas encore, plus tard ",
"La communication est souvent très érèctive car c'est l'homme qui commande",
" Dans votre vie la moitié des réunions seront dirigées par des pignoufs. ",
"- Et vous Raphaël, qui êtes branché cul. Vous avez déjà fait des vidéos de cul ? \n- Non.\n- Parce que vous êtes encore jeune. Vous en ferez plus tard vous verrez, avec l'âge elles sont plus dociles.",
"Vous verrez avec l'âge elles sont plus dociles",
"Avec tout ces mouvements féministes on a même plus de femmes qui embrassent les cyclistes au Tour de France. Bientôt on aura même plus d'hôtesses devant les voitures. Je trouve ça dommage, j'aime bien les jeunes filles moi.",
" La compta c'est pas un job bandant. C'est comme la coiffure, on fait ça quand on sait rien faire. ",
" Le feu, la vieille et le black. Là on a le triptyque. ",
"Je ne considère pas la femme comme un objet, jamais ! Un porte monnaie ok mais pas objet",
"Y aller avec sa bite et son couteau",
"Quand le trou est ouvert on fait passer ce qu'on veut",
"Maintenant vous regardez le cul d'une fille vous avez un procès",
"Moi je fais des soirées à l'EHPAD",
"quand vous faites des soirées, parce que vous vous êtes jeunes. Moi je fais plutôt des soirées à l'EHPAD",
"y a un karma dans la vie",
"Ca s'appelle la fonction public quand quelqu'un sert à rien",
"Hamid: bonjour je suis mamadou je suis au sénégal j'ai besoin d'argent",
"L'IA c'est comme une recette de gâteau",
"- Katmandou c'est la capitale de quoi ?\n- du népal\n- ah c'est en amérique latine ?\n- non c'est en afrique",
"Quand il n'y a pas de covid c'est les gens qui ont le cancer qui portent un masque"};
            return '`' + tab[rnd.Next(0, tab.Count() - 1)] + '`';
            
        }
    }
}
