using System;
using Keystone.Net.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Keystone.Net
{
    public static class KeystoneServiceCollectionExtensions
    {
        public static IServiceCollection AddKeystoneClient(this IServiceCollection services, IConfiguration config)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            services.AddOptions();

            var option = new KeystoneOption(config);

            services.AddHttpClient<AuthenticationService>(c => { c.BaseAddress = new Uri(option.Uri); });
            services.AddHttpClient<CredentialService>(c => { c.BaseAddress = new Uri(option.Uri); });
            services.AddHttpClient<DomainService>(c => { c.BaseAddress = new Uri(option.Uri); });
            services.AddHttpClient<GroupService>(c => { c.BaseAddress = new Uri(option.Uri); });
            services.AddHttpClient<ProjectService>(c => { c.BaseAddress = new Uri(option.Uri); });
            services.AddHttpClient<RegionService>(c => { c.BaseAddress = new Uri(option.Uri); });
            services.AddHttpClient<RoleService>(c => { c.BaseAddress = new Uri(option.Uri); });
            services.AddHttpClient<UserService>(c => { c.BaseAddress = new Uri(option.Uri); });

            return services;
        }
    }
}