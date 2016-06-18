using Consul;
using Microsoft.Extensions.Configuration.Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Configuration
{
    public static class ConsulConfigurationExtensions
    {
        //public static IConfigurationBuilder AddConsul(this IConfigurationBuilder builder)
        //{
        //    return AddConsul(builder, new Uri("http://127.0.0.1:8500"),null);
        //}


        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder builder, Uri address=null,string prefix=null)
        {
            if (address == null)
            {
                address =new Uri("http://127.0.0.1:8500");
            }
            builder.Add(new ConsulConfigurationSource { Address = address,Prefix=prefix });
            return builder;
        }
    }
}
