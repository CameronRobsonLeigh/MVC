using Sitecore.DependencyInjection;
using SiteCoreProject.Interfaces;
using SiteCoreProject.Services;
using Microsoft.Extensions.DependencyInjection;
using SiteCoreProject.Controllers;
using SiteCoreProject.Repositorys;

namespace SiteCoreProject.DI
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(LinkedController));
            serviceCollection.AddTransient<IHeaderService, HeaderService>();
            serviceCollection.AddTransient<IMainRepository, MainRepository>();
            serviceCollection.AddTransient<ITopNavigationService, TopNavigationService>();
            serviceCollection.AddTransient<IFooterService, FooterService>();
            serviceCollection.AddTransient<ITopNavigationRepository, TopNavigationRepository>();
        }
    }
}