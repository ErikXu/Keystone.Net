using System;
using Microsoft.Extensions.Configuration;

namespace Keystone.Net
{
    public class KeystoneOption
    {
        public KeystoneOption(IConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var section = config.GetSection("keystone");
            section.Bind(this);
        }

        public string Uri { get; set; }
    }
}