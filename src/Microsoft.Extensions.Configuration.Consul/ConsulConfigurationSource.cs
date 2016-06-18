using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Configuration.Consul
{
    public class ConsulConfigurationSource : IConfigurationSource
    {

        public Uri  Address { get; set; }

        public string Prefix { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ConsulConfigurationProvider(Address,Prefix);
        }
    }
}
