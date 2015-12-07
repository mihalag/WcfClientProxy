using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientProxy
{
    public class TimeoutChannelFactoryProviderDecorator<TWcfServiceInterface> : IChannelFactoryProvider<TWcfServiceInterface> where TWcfServiceInterface : class
    {
        private readonly IChannelFactoryProvider<TWcfServiceInterface> _channelFactoryProvider;

        /// <summary>
        /// Таймаут.
        /// </summary>
        private readonly TimeSpan _timeout;

        public TimeoutChannelFactoryProviderDecorator(IChannelFactoryProvider<TWcfServiceInterface> channelFactoryProvider, TimeSpan timeout)
        {
            _channelFactoryProvider = channelFactoryProvider;
            _timeout = timeout;
        }

        public ChannelFactory<TWcfServiceInterface> GetChannelFactory()
        {
            var channelFactory = _channelFactoryProvider.GetChannelFactory();
            channelFactory.Endpoint.Binding.OpenTimeout = _timeout;
            channelFactory.Endpoint.Binding.CloseTimeout = _timeout;
            channelFactory.Endpoint.Binding.SendTimeout = _timeout;
            channelFactory.Endpoint.Binding.ReceiveTimeout = _timeout;
            return channelFactory;
        }
    }
}
