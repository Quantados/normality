using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using normality.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace normality
{
    public class Bot
    {
        public DiscordClient Client { get; private set;  }
        public CommandsNextExtension Commands {  get; private set; }
       
        public async Task RunAsync()
        
        {
            var json = string.Empty;
            using(var fs = File.OpenRead("config.json")) 
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configjson = JsonConvert.DeserializeObject<Configjson>(json);

            var config = new DiscordConfiguration()
            {
                Token = configjson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };
            
            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;
            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] {configjson.Prefix},
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true,
                UseDefaultCommandHandler = true,
            };
            
            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<FunCommands>();
            Commands.RegisterCommands<ModerationCmds>();


            await Client.ConnectAsync();
            await Task.Delay(-1);        
            }
    
        private Task OnClientReady(object sender, ReadyEventArgs e)

        {
            return Task.CompletedTask;
        }
    }
}
