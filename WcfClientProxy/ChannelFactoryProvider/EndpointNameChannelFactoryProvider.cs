using System.ServiceModel;

namespace WcfClientProxy.ChannelFactoryProvider
{
    public class EndpointNameChannelFactoryProvider<TWcfServiceInterface> : IChannelFactoryProvider<TWcfServiceInterface> where TWcfServiceInterface : class
    {
        private readonly string _endpointConfigurationName;

        public EndpointNameChannelFactoryProvider(string endpointConfigurationName)
        {
            _endpointConfigurationName = endpointConfigurationName;
        }

        public ChannelFactory<TWcfServiceInterface> GetChannelFactory()
        {
            return new ChannelFactory<TWcfServiceInterface>(_endpointConfigurationName);
        }
    }
}
