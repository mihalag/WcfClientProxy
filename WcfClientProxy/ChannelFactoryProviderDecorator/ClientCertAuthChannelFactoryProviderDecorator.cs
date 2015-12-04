using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WcfClientProxy
{
    public class ClientCertAuthChannelFactoryProviderDecorator<TWcfServiceInterface> : IChannelFactoryProvider<TWcfServiceInterface> where TWcfServiceInterface : class
    {
        private readonly IChannelFactoryProvider<TWcfServiceInterface> _channelFactoryProvider;

        /// <summary>
        /// Сертификат для аутентификации.
        /// </summary>
        private readonly X509Certificate2 _certificate;

        public ClientCertAuthChannelFactoryProviderDecorator(IChannelFactoryProvider<TWcfServiceInterface> channelFactoryProvider)
        {
            _channelFactoryProvider = channelFactoryProvider;
        }

        public ChannelFactory<TWcfServiceInterface> GetChannelFactory()
        {
            var channelFactory = _channelFactoryProvider.GetChannelFactory();
            var clientCredentials = new ClientCredentials();
            clientCredentials.ClientCertificate.Certificate = _certificate;
            channelFactory.Endpoint.Behaviors.RemoveAll<ClientCredentials>();
            channelFactory.Endpoint.Behaviors.Add(clientCredentials);
            return channelFactory;
        }
    }
}
