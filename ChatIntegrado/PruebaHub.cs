using Microsoft.AspNetCore.SignalR;

namespace ChatIntegrado
{
    public class PruebaHub : Hub
    {

        public override Task OnConnectedAsync()
        {
            
            Console.WriteLine("Usuario conectado");
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine("Usuario desconectado");
            return base.OnDisconnectedAsync(exception);

        }

        public async Task SendMessage(string message) //ENVIAR MENSAJE
        {
            await Clients.Others.SendAsync("AwaitMessage", message);
        }

        
    }
}
