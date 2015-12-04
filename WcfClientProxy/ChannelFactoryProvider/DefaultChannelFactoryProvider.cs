using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientProxy.ChannelFactoryProvider
{
    public class DefaultChannelFactoryProvider<TWcfServiceInterface> : IChannelFactoryProvider<TWcfServiceInterface> where TWcfServiceInterface : class
    {
        public ChannelFactory<TWcfServiceInterface> GetChannelFactory()
        {
            return new ChannelFactory<TWcfServiceInterface>();
        }
    }
}
