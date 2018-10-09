using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Escrotinho.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet("{aplicationKey}")]
        public ActionResult ListarLog(string aplicationKey)
        {
            if(!Bot.ConfiguracaoBot.TokenValida(aplicationKey))
            {
                Bot.Logger.EscrotinhoLogger.Mensagem("Tentativa de acesso não autorizado.", Bot.Logger.TipoLog.Alerta);
                return NotFound();
            }

            return Content(string.Join('\n', Bot.Logger.EscrotinhoLogger.ObterLogs().Select(l => l.ToString())));
        }
    }
}
