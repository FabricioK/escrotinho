using Discord;
using Escrotinho.Bot.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Escrotinho.Bot.Logger
{
    public static class EscrotinhoLogger
    {
        private static Queue<Log> Logs = new Queue<Log>();

        private static int QuantidadeDeLogsMaximo => lazyQuantidade.Value;
        private static TipoLog NivelDeLog => lazyNivel.Value;

        private static Lazy<int> lazyQuantidade = new Lazy<int>(() => ConfiguracaoBot.QuantidadeDeLogs ?? 500);
        private static Lazy<TipoLog> lazyNivel = new Lazy<TipoLog>(() => ConfiguracaoBot.NivelDeLog ?? TipoLog.Erro);

        internal async static Task DiscordLog(LogMessage logMsg)
        {
            if(logMsg.Exception != null)
            {
                await Mensagem(logMsg.Exception.Message, TipoLog.Erro);
            }
            else
            {
                if(LogSeverity.Critical == logMsg.Severity || LogSeverity.Error == logMsg.Severity) {
                    await Mensagem(logMsg.Source + ": " + logMsg.Message, TipoLog.Erro);
                }
                else if (LogSeverity.Debug == logMsg.Severity || LogSeverity.Info == logMsg.Severity || LogSeverity.Verbose == logMsg.Severity)
                {
                    await Mensagem(logMsg.Source + ": " + logMsg.Message, TipoLog.Info);
                }
                else if (LogSeverity.Warning == logMsg.Severity)
                {
                    await Mensagem(logMsg.Source + ": " + logMsg.Message, TipoLog.Alerta);
                }
            }
        }

        public async static Task Mensagem(string mensagem, TipoLog tipo)
        {
            var log = new Log(tipo, mensagem);
            await AdicionarLog(log);
        }

        public async static Task Exception(BotException exception)
        {
            await Mensagem(exception.Message, TipoLog.Erro);
        }

        public static ICollection<Log> ObterLogs() => Logs.ToArray();

        private async static Task AdicionarLog(Log log)
        {
            await Task.Run(() =>
            {
                if (log.Tipo < NivelDeLog)
                    return;

                lock(Logs)
                {
                    if (Logs.Count == QuantidadeDeLogsMaximo)
                    {
                        Logs.Dequeue();
                    }
                    Logs.Enqueue(log);
                }
            });
            
        }
    }
}
