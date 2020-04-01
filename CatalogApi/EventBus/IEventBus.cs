using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CatalogApi.Events;

namespace CatalogApi.EventBus
{
    interface IEventBus
    {
        void Publish(IntegrationEvents @event);

        void Subscribe<T, TH>() where T : IntegrationEvents where TH : IntegrationEventHandler<T>;

        void SubscribeDynamic<TH>(String EventName) where TH : IDynamicIntegrationEventHandlercs;

        void UnSubscribeDynamic<TH>(String EventName) where TH : IDynamicIntegrationEventHandlercs;

        void Unsubscribe<T,TH>() where T : IntegrationEvents where TH : IntegrationEventHandler<T>;
    }
}
