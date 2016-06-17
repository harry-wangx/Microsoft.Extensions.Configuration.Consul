using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Configuration.Consul
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsulConfigurationProvider : ConfigurationProvider
    {
        //private static Char KeySeparator = '/';

        private ConsulClient _consulClient = null;

        private string _prefix = null;

        public ConsulConfigurationProvider(Uri address,string prefix)
        {
            _prefix = prefix;

            _consulClient =
                new ConsulClient(
                    new ConsulClientConfiguration
                    {
                        Address = address
                    }
                );
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Load()
        {
            IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        var result = _consulClient.KV.List(_prefix).Result;
            if (result != null && result.Response != null)
            {
                foreach (var item in result.Response)
                {

                    Console.WriteLine(string.Format("{0}   {1}", item.Key, item.Value != null ? System.Text.Encoding.UTF8.GetString(item.Value) : ""));
                }
            }
        }
    }
}
