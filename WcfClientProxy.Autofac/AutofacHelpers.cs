using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace WcfClientProxy.Autofac
{
    public static class AutofacHelpers
    {
        public static ContainerBuilder RegisterWcfProxy<T>(this ContainerBuilder containerBuilder, IChannelFactoryProvider<T> channelFactoryProvider)  where T : class
        {
            containerBuilder.Register(c => new ClientProxyGenerator().CreateProxy<T>(channelFactoryProvider)).As<T>();
            return containerBuilder;
        }
    }
}
