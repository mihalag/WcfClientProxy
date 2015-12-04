using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace WcfClientProxy
{
    public class ClientProxyGenerator
    {
        private readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();

        /// <summary> Создаёт класс-посредник для работы с WCF-сервисом. </summary>
        public TWcfServiceInterface CreateProxy<TWcfServiceInterface>(IChannelFactoryProvider<TWcfServiceInterface> channelFactoryProvider) where TWcfServiceInterface : class
        {
            return _proxyGenerator.CreateInterfaceProxyWithoutTarget<TWcfServiceInterface>(new WcfProxyInterceptor<TWcfServiceInterface>(channelFactoryProvider));
        }
    }
}
