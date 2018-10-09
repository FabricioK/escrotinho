using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escrotinho.Bot
{
    internal class ControladorBot
    {
        public static ControladorBot Instancia => lazy.Value;
        private static Lazy<ControladorBot> lazy = new Lazy<ControladorBot>(() => new ControladorBot());


        private DiscordSocketClient client;


        internal ControladorBot()
        {
            client = new DiscordSocketClient();

            client.Log += Logger.EscrotinhoLogger.DiscordLog;

            client.LoginAsync(TokenType.Bot, ConfiguracaoBot.BotToken).Wait();
            client.StartAsync().Wait();
        }


    }
}
