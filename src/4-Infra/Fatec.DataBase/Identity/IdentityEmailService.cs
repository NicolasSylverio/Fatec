using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Fatec.DataBase.Identity
{
    class IdentityEmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Conecte o seu serviço de email aqui para enviar um email.
            return Task.FromResult(0);
        }
    }
}