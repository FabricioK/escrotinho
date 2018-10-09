using System.Collections.Generic;
using System.Text;

namespace Escrotinho.Bot.Exceptions.Configuracao
{
    class ConfiguracaoJaIniciadaException : BotException
    {
        public ConfiguracaoJaIniciadaException() :base(BotError.ConfiguracaoJaInicializada)
        {
        }
    }
}
