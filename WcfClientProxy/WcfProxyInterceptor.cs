using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace WcfClientProxy
{
    public class WcfProxyInterceptor<TWcfServiceInterface> : IInterceptor where TWcfServiceInterface : class
    {
        private readonly ChannelFactory<TWcfServiceInterface> _channelFactory;

        public WcfProxyInterceptor(IChannelFactoryProvider<TWcfServiceInterface> channelFactoryProvider)
        {
            _channelFactory = channelFactoryProvider.GetChannelFactory();
        }

        public void Intercept(IInvocation invocation)
        {
            IClientChannel channel = null;
            try
            {
                channel = (IClientChannel)_channelFactory.CreateChannel();
                channel.Open();
                invocation.ReturnValue = invocation.Method.Invoke(channel, invocation.Arguments);
                channel.Close();
            }
            catch (Exception e)
            {
                if (channel != null)
                    channel.Abort();

                var ex = e as TargetInvocationException;
                if (ex != null)
                    throw ex.InnerException;

                throw;
            }
        }
    }
}
