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
    public class SobreController : ControllerBase
    {
        [HttpGet("Version")]
        public string Version()
        {
            return Assembly.GetEntryAssembly().GetName().Version.ToString();
        }

        [HttpGet("Name")]
        public string Name()
        {
            return Assembly.GetEntryAssembly().GetName().Name;
        }

        [HttpGet]
        public string Sobre()
        {
            return $"Nome: {Name()}\n" +
                   $"Versão: {Version()}";
        }
    }
}
