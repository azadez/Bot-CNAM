using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot_CNAM
{
    class Pause
    {
        public static int cpt = 0;
        public Pause()
        {

        }

        public static void fairepause10m()
        {
            for (cpt = 0; cpt < 600; cpt++)
            {
                Thread.Sleep(1000);
            }
            Modules.Commands.pause = false;
        }
    }
}
