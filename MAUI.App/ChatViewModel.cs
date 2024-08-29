using Microsoft.AspNetCore.SignalR.Client;

namespace MAUI.App
{
    public class ChatViewModel
    {
        private readonly HubConnection _hubConnection;

        public ChatViewModel()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5178/chathub")
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                // Handle the received message
            });
        }

        public async Task ConnectAsync()
        {
            await _hubConnection.StartAsync();
        }

        public async Task SendMessageAsync(string user, string message)
        {
            await _hubConnection.InvokeAsync("SendMessage", user, message);
        }
    }
}
