using AutoMapper;
using CleanNet.Application.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace CleanNet.Application.Services;

public class MessageService : IMessageService
{
    public MessageService()
    {

    }

    public void Publish(String message)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "logs", routingKey: "", basicProperties: null, body: body);
    }
}
