using System;
using System.Threading.Tasks;
using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Bot_CNAM
{
    class Program
    {
        private DiscordSocketClient client;
        private CommandService commands;

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            commands = new CommandService();

            client.Log += Log;

            client.Ready += () =>
            {
                Console.WriteLine("Je suis pret");
                return Task.CompletedTask;
            };

            await InstallCommandsAsync();

            await client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("TokenDiscord",EnvironmentVariableTarget.User));
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        public async Task InstallCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);
        }

        private async Task HandleCommandAsync(SocketMessage pMessage)
        {
            var message = (SocketUserMessage)pMessage;
            if (message == null) return;

            int argPos = 0;

            if (!message.HasCharPrefix('!', ref argPos)) return;

            var context = new SocketCommandContext(client, message);
            var result = await commands.ExecuteAsync(context, argPos, null);
            if (!result.IsSuccess) await context.Channel.SendMessageAsync(result.ErrorReason);
        }

    }
}

