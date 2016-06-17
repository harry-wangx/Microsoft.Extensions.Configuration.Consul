using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Configuration.Consul
{
    public static class ConsulConfigurationExtensions
    {
        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder builder)
        {
            return AddConsul(builder, new Uri("http://127.0.0.1:8500"));
        }

        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder builder, Uri address)
        {
            builder.Add(new ConsulConfigurationSource { Address = address });
            return builder;
        }
    }
}
