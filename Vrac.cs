using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot_CNAM
{
    class Vrac
    {
        public static string anniv(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Joyeux anniversaireeeeeee");
            sb.AppendLine("Joyeux anniversaireeeeeee");
            sb.AppendLine($"Joyeux anniversaire {str}");
            sb.AppendLine("Joyeux anniversaireeeeeeee");
            return sb.ToString();
        }

        public static void Sleep(int time, Modules.Commands cmd)
        {
            Thread.Sleep(time * 60000);
            cmd.Msg("@everyone fin de la pause les cocos");
        }
    }
}
