using System;
using System.IO;
using DSharpPlus;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;

namespace WereBot
{
    class Program
    {
        public class MyDiscordSettingsConfig
            {
                public string AccountName { get; set; }
                public string DiscordToken { get; set; }
                public string ApiSecret { get; set; }
                public string Prefix { get; set; }
            }
        static DiscordClient discord;
        static CommandsNextModule commands;
        static InteractivityModule interactivity;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            IConfigurationRoot configuration = builder.Build();
            var myDiscordSettingsConfig = new MyDiscordSettingsConfig();
            configuration.GetSection("DiscordSettings").Bind(myDiscordSettingsConfig);

            Console.WriteLine("DiscordToken: " + myDiscordSettingsConfig.DiscordToken);
            Console.WriteLine("Prefix: " + myDiscordSettingsConfig.Prefix);


            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = myDiscordSettingsConfig.DiscordToken,
                TokenType = TokenType.Bot,

                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });


            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = myDiscordSettingsConfig.Prefix
            });

            commands.RegisterCommands<MyCommands>();
            interactivity = discord.UseInteractivity(new InteractivityConfiguration
            {

            });

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
