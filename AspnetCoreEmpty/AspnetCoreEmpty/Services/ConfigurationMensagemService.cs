using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreEmpty.Services
{
    public class ConfigurationMensagemService : IMensagemService
    {
        private IConfiguration _config;

        public ConfigurationMensagemService(IConfiguration config)
        {
            _config = config;
        }
        public string GetMensagem()
        {
            throw new Exception("Testando variáveis de ambiente");
            return _config["Mensagem"];
            
        }
    }
}
