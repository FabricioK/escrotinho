using System;

namespace Escrotinho.Bot.Logger
{
    public class Log
    {
        public TipoLog Tipo { get; private set; }
        public DateTime Quando { get; private set; }
        public string Descricao { get; private set; }

        internal Log(TipoLog tipo, string descricao)
        {
            Tipo = tipo;
            Descricao = descricao;
            Quando = DateTime.Now;
        }

        public override string ToString()
        {
            return Quando.ToString("yyyy-MM-dd hh:mm:ss") + " - " + Tipo.ToString() + " - " + Descricao;
        }
    }
}
