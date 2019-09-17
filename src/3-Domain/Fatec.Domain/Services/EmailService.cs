using System.Threading.Tasks;

namespace Fatec.Domain.Services
{
    /// <summary>
    ///     Classe para serviços de E-mail
    /// </summary>
    public class EmailService
    {
        public Task SendAsync(string message)
        {
            // Conecte o seu serviço de email aqui para enviar um email.
            return Task.FromResult(0);
        }
    }
}