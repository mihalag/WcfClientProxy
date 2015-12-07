using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientProxy
{
    public class BasicAuthChannelFactoryProviderDecorator<TWcfServiceInterface> : IChannelFactoryProvider<TWcfServiceInterface> where TWcfServiceInterface : class
    {
        private readonly IChannelFactoryProvider<TWcfServiceInterface> _channelFactoryProvider;

        /// <summary>
        /// Имя пользователя для аутентификации.
        /// </summary>
        private readonly string _userName;

        /// <summary>
        /// Пароль пользователя для аутентификации.
        /// </summary>
        private readonly string _password;

        public BasicAuthChannelFactoryProviderDecorator(IChannelFactoryProvider<TWcfServiceInterface> channelFactoryProvider, string userName, string password)
        {
            _channelFactoryProvider = channelFactoryProvider;
            _userName = userName;
            _password = password;
        }

        public ChannelFactory<TWcfServiceInterface> GetChannelFactory()
        {
            var channelFactory = _channelFactoryProvider.GetChannelFactory();
            var clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = _userName;
            clientCredentials.UserName.Password = _password;
            channelFactory.Endpoint.Behaviors.RemoveAll<ClientCredentials>();
            channelFactory.Endpoint.Behaviors.Add(clientCredentials);
            return channelFactory;
        }
    }
}
