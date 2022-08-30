using System;
using RabbitMQ.Client;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using statistique.Models;

namespace statistique.Services.RabbitMQ
{

    public class Send
    {

        public  string   queuName = "hello"; 


        public void Connection(Notification notification )
        {

            var Factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = Factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queuName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

             
                string jsonString = JsonSerializer.Serialize(notification);
                var body = Encoding.UTF8.GetBytes(jsonString);
                channel.BasicPublish(exchange: "",
                                     routingKey: queuName,
                                     body: body);
                System.Diagnostics.Debug.WriteLine(body);
            }
        }
   
    }
}