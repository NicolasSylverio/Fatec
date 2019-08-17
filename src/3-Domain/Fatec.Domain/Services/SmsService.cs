using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Domain.Services
{
    public class SmsService
    {
        public Task SendAsync(string message)
        {
            // Conecte seu serviço de SMS aqui para enviar uma mensagem de texto.
            return Task.FromResult(0);
        }
    }
}