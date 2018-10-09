using System;

namespace Escrotinho.Bot.Exceptions
{
    public class BotException : Exception
    {
        internal BotException(BotError error) : base($"Erro {(int)error}.")
        {}
    }
}
