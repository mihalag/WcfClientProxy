using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientProxy
{
    public static class ChannelFactoryProviderHelpers
    {
        public static IChannelFactoryProvider<TWcfServiceInterface> WithBasicAuth<TWcfServiceInterface>(
            this IChannelFactoryProvider<TWcfServiceInterface> channelFactoryProvider, string login, string password) where TWcfServiceInterface : class
        {     
            return new BasicAuthChannelFactoryProviderDecorator<TWcfServiceInterface>(channelFactoryProvider, login, password);
        }

        public static IChannelFactoryProvider<TWcfServiceInterface> WithTimeout<TWcfServiceInterface>(
            this IChannelFactoryProvider<TWcfServiceInterface> channelFactoryProvider, TimeSpan timeout) where TWcfServiceInterface : class
        {
            return new TimeoutChannelFactoryProviderDecorator<TWcfServiceInterface>(channelFactoryProvider, timeout);
        }
    }
}
