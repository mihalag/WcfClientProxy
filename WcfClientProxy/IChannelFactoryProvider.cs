using System.ServiceModel;

namespace WcfClientProxy
{
    public interface IChannelFactoryProvider<TWcfServiceInterface> where TWcfServiceInterface : class
    {
        ChannelFactory<TWcfServiceInterface> GetChannelFactory();
    }
}
