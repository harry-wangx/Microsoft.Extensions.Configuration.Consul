using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ConsulConfigurationProvider(Uri address, string prefix)
        {
            _prefix = prefix;
            if (!string.IsNullOrEmpty(_prefix))
            {
                _prefix = _prefix.Trim();
            }

            _consulClient =
                new ConsulClient(
                    new ConsulClientConfiguration
                    {
                        Address = address
                    }
                );
        }

        /// <summary>
        /// 读取配置信息
        /// </summary>
        public override void Load()
        {
            //IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var result = _consulClient.KV.List(_prefix).Result;
            if (result != null && result.StatusCode== HttpStatusCode.OK && result.Response != null)
            {
                foreach (var item in result.Response)
                {
                    if (!item.Key.EndsWith("/") && item.Value != null)
                    {
                        if (string.IsNullOrEmpty(_prefix))
                        {
                            Set(item.Key.Replace('/', ':'), System.Text.Encoding.UTF8.GetString(item.Value));
                        }
                        else
                        {
                            Set(item.Key.Substring(_prefix.Length+1).Replace('/', ':'), System.Text.Encoding.UTF8.GetString(item.Value));
                        }
                        
                    }
                }
            }
        }
    }
}
