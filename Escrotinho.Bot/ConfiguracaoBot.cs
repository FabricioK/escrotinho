using Escrotinho.Bot.Exceptions.Configuracao;
using Escrotinho.Bot.Logger;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escrotinho.Bot
{
    public static class ConfiguracaoBot
    {
        public static bool Inicializado { get; private set; } = false;
        internal static string BotToken { get; private set; }
        internal static string ApiToken { get; private set; }
        public static int? QuantidadeDeLogs { get; internal set; }
        public static TipoLog? NivelDeLog { get; internal set; }

        public static bool TokenValida(string apiToken)
        {
            return ApiToken == apiToken;
        }

        public static void Inicializar(IConfiguration configuration)
        {
            if (Inicializado) throw new ConfiguracaoJaIniciadaException();

            BotToken = configuration["BotToken"];
            ApiToken = configuration["ApiToken"];
            if (int.TryParse(configuration["QuantidadeDeLogs"], out var quatidade))
            {
                QuantidadeDeLogs = quatidade;
            }
            if (Enum.TryParse<TipoLog>(configuration["NivelDeLog"], out var nivel))
            {
                NivelDeLog = nivel;
            }
        }
    }
}
