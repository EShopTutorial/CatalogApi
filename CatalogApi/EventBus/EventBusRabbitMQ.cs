using CatalogApi.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using CatalogApi.Factory;
using Newtonsoft.Json;
using System.Text;

using RabbitMQ.Client;

namespace CatalogApi.EventBus
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
      
        public string _connectionString ="";
        public string _brokerName = "";
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Publish(IntegrationEvents @event)
        {
            var eventName = @event.GetType().Name;
            var factory = new ConnectionFactory() { HostName = _connectionString };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: _brokerName,
                type: "direct");

                string message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                
                channel.BasicPublish(exchange: _brokerName,
                routingKey: eventName,
                basicProperties: null,
                body: body);
            }
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvents
            where TH : IntegrationEventHandler<T>
        {
            //var eventName = _subsManager.GetEventKey<T>();
            //var containsKey = _subsManager.HasSubscriptionsForEvent(eventName);
            //if (!containsKey)
            //{
            //    if (!_persistentConnection.IsConnected)
            //    {
            //        _persistentConnection.TryConnect();
            //    }
            //    using (var channel = _persistentConnection.CreateModel())
            //    {
            //        channel.QueueBind(queue: _queueName,
            //        exchange: BROKER_NAME,
            //        routingKey: eventName);
            //    }
            //}
            //_subsManager.AddSubscription<T, TH>();
        }

        public void SubscribeDynamic<TH>(string EventName) where TH : IDynamicIntegrationEventHandlercs
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvents
            where TH : IntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void UnSubscribeDynamic<TH>(string EventName) where TH : IDynamicIntegrationEventHandlercs
        {
            throw new NotImplementedException();
        }

       
    }
}