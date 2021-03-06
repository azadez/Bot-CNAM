﻿using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot_CNAM.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        public static bool pause = false;
        edt edt = new edt();
        blague blague = new blague();
        quote quote = new quote();

        [Command("help")]
        public async Task helpasycn()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"```Je t'aide mais t'es quand meme un fils de poule ");
            str.AppendLine();
            str.AppendLine($"!edt pour avoir la semaine actuelle de l'edt");
            str.AppendLine($"!edtnext pour avoir la semaine suivante");
            str.AppendLine($"!shuffle pour faire chier le monde en vocal mais avec modération stp");
            str.AppendLine($"!rassemblement pour faire revenir tout le monde au general");
            str.AppendLine($"!anniv @tag pour souhaiter un bon anniversaire à @tag");
            str.AppendLine($"!quote pour avoir une citation du hallivier of fame");
            str.AppendLine($"!pilon pour avoir des conseils");
            str.AppendLine($"!help pour aller te faire enculer");
            str.AppendLine($"!chugo pour la masterclasse");
            str.AppendLine($"!joke pour une petite balgue");
            str.AppendLine($"!vdm pour se dire qu'on est pas seul comme merde");
            str.AppendLine($"```");

            await ReplyAsync(str.ToString());
        }

        [Command("pilon")]
        public async Task tagasync()
        {
            await ReplyAsync("<@!401020032521469962> tu es demandé s'il te plait :smoking:");
        }

        [Command("chugo")]
        public async Task chugoasync()
        {
            await ReplyAsync("c'est hugo",true);
        }
       
        [Command("quote")]
        public async Task quoteasync()
        {
            await ReplyAsync(quote.rand());
        }

        [Command("joke")]
        public async Task jokeasync()
        {
            await ReplyAsync(blague.joke());
        }

        [Command("vdm")]
        public async Task vdmasync()
        {
            await ReplyAsync(blague.vdm());
        }


        [Command("edt")]
        public async Task edtasync(params string[] tab)
        {
            string x = edt.Getedt(false).Result;
            await ReplyAsync(x);
        }

        [Command("edtnext")]
        public async Task edtnextasync(params string[] tab)
        {
            string x = edt.Getedt(true).Result;
            await ReplyAsync(x);
        }

        [Command("anniv")]
        public async Task annivasync(string str)
        {
            await ReplyAsync(Vrac.anniv(str),true);
        }

        [Command("shuffle")]
        public async Task shuffle()
        {
            if (!pause)
            {
                pause = true;
                var myThread = new Thread(new ThreadStart(Pause.fairepause10m));
                myThread.Start();
                var rand = new Random();
                var listchannel = Context.Guild.VoiceChannels;
                var user = Context.Guild.Users.Where(x => x.VoiceChannel != null).ToList();
                foreach (var u in user)
                {
                    u.ModifyAsync(x => x.Channel = listchannel.ElementAt(rand.Next(0, listchannel.Count())));
                    Thread.Sleep(30);
                }
                await ReplyAsync("Shuffle terminé");
            }
            else
            {
                await ReplyAsync($"Il reste {600-Pause.cpt} secondes avant de pouvoir shuffle");
            }
        }

        [Command("rassemblement")]
        public async Task rassemblementasync()
        {
            var user = Context.Guild.Users.Where(x => x.VoiceChannel != null).ToList();
            foreach (var u in user)
            {
                u.ModifyAsync(x => x.Channel = Context.Guild.GetVoiceChannel(ulong.Parse("622001239009263630")));
                Thread.Sleep(5);
            }
            await ReplyAsync("Tous au bercail");
        }

        [Command("sleep")]
        public async Task Sleepsaync(int x)
        {
            new Thread(() => Vrac.Sleep(x, this)).Start();
        }


        public async Task Msg(string msg)
        {
            await ReplyAsync(msg);
        }

    }
}
