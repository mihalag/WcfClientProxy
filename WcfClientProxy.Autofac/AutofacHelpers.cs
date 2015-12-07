using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WcfClientProxy.ChannelFactoryProvider;

namespace WcfClientProxy.Autofac
{
    public static class AutofacHelpers
    {
        public static ContainerBuilder RegisterWcfProxy<T>(this ContainerBuilder containerBuilder, IChannelFactoryProvider<T> channelFactoryProvider)  where T : class
        {
            containerBuilder.Register(c => new ClientProxyGenerator().CreateProxy<T>(channelFactoryProvider)).As<T>();
            return containerBuilder;
        }

        public static ContainerBuilder RegisterWcfProxy<T>(this ContainerBuilder containerBuilder, Func<ChannelFactoryProviderRegistration<T>, IChannelFactoryProvider<T>> channelFactoryProviderRegistration) where T : class
        {
            containerBuilder.Register(c => new ClientProxyGenerator().CreateProxy<T>(channelFactoryProviderRegistration(new ChannelFactoryProviderRegistration<T>()))).As<T>();
            return containerBuilder;
        }

        
    }

    public class ChannelFactoryProviderRegistration<T> where T : class
    {
        public IChannelFactoryProvider<T> FromEndpointConfigurationName(string endpointConfigurationName)
        {
            return new EndpointNameChannelFactoryProvider<T>(endpointConfigurationName);
        }
    }
}
