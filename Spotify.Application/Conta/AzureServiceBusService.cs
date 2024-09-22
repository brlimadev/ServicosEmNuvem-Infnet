using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using SpotifyLike.Domain.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Spotify.Application.Conta
{
    public class AzureServiceBusService
    {
        //Preciso de uma connectionstring pra chegar no serviço
        private string ConnectionString;

        //Como vou receber isso atraves desse AzureServiceBusService
        public AzureServiceBusService(IConfiguration configuration)
        {
            this.ConnectionString = configuration["AzureServiceBus:ConnectionString"];
        }

        //Método que envia a mensagem
        public async Task SendMessage(Notificacao notificacao)
        {
            //Preciso de um cliente pra conectar no ServiceBus
            ServiceBusClient client;
            //Vou precisar de um cara que envia
            ServiceBusSender sender;
            //Client pega o cara que envia pela connectionstring
            client = new ServiceBusClient(this.ConnectionString);
            // Para qual fila to enviando
            sender = client.CreateSender("notification");
            //Criar a mensagem no padrao que o azure precisa em Json Mesmo
            var body = JsonSerializer.Serialize(notificacao);
            // A mensage recebe o body
            var message = new ServiceBusMessage(body);
            //Mandar enfileirar as mensagens
            await sender.SendMessageAsync(message);
        }
    }
}