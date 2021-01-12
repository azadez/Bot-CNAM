using Discord.Commands;
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
        edt edt = new edt();
        blague blague = new blague();
        quote quote = new quote();

        [Command("help")]
        public async Task helpasycn()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"```Je t'aide mais t'es quand meme un fils de poule ");
            str.AppendLine();
            str.AppendLine($"!quote pour avoir une citation du hallivier of fame");
            str.AppendLine($"!pilon pour avoir des conseils");
            str.AppendLine($"!help pour aller te faire enculer");
            str.AppendLine($"!chugo pour la masterclasse```");
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
            var rand = new Random();
            var listchannel = Context.Guild.VoiceChannels;
            var user = Context.Guild.Users;
            foreach (var u in user)
            {
                u.ModifyAsync(x => x.Channel = listchannel.ElementAt(rand.Next(0, listchannel.Count() - 1)));
                Thread.Sleep(30);
            }
            await ReplyAsync("Shuffle terminé");
        }

    }
}
