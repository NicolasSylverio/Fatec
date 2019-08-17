using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Fatec.Domain.Identity
{
    class IdentitySmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Conecte seu serviço de SMS aqui para enviar uma mensagem de texto.
            return Task.FromResult(0);
        }
    }
}
