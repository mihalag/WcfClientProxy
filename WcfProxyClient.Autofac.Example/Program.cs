using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WcfClientProxy;
using WcfClientProxy.Autofac;

namespace WcfProxyClient.Autofac.Example
{
    public interface ISomeService
    {
        void Do();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterWcfProxy<ISomeService>( reg => reg.FromEndpointConfigurationName("myEndPoint")
                .WithBasicAuth("login", "password")
                .WithTimeout(TimeSpan.FromSeconds(30)));
            var container = containerBuilder.Build();

        }
    }
}
