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
        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder builder)
        {
            return AddConsul(builder,null);
        }

        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder builder, Action<ConsulConfigurationOptions> optionsAction)
        {
            ConsulConfigurationOptions options = new Consul.ConsulConfigurationOptions();
            optionsAction?.Invoke(options);


            if (options.Address == null)
            {
                options.Address = new Uri("http://127.0.0.1:8500");
            }
            if (options.Prefix != null)
            {
                options.Prefix = options.Prefix.Trim().Replace(':', '/');
            }
            builder.Add(new ConsulConfigurationSource { Options = options });
            return builder;
        }

        [Obsolete]
        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder builder, Uri address = null, string prefix = null)
        {
            return AddConsul(builder, options => {
                options.Address = address;
                options.Prefix = prefix;
            });
        }
    }
}
