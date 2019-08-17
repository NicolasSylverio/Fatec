using System.Threading.Tasks;

namespace Fatec.Domain.Services
{
    public class EmailService
    {
        public Task SendAsync(string message)
        {
            // Conecte o seu serviço de email aqui para enviar um email.
            return Task.FromResult(0);
        }
    }
}
