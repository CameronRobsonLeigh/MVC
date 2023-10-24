using SiteCoreProject.Fields;
using SiteCoreProject.Interfaces;
using SiteCoreProject.Models;

namespace SiteCoreProject.Services
{
    public class TopNavigationService : ITopNavigationService
    {
        private readonly ITopNavigationRepository _topNavigationRepository;

        public TopNavigationService(ITopNavigationRepository topNavigationRepository)
        {
            _topNavigationRepository = topNavigationRepository;
        }

        public TopNavigationModel HeaderNavigation()
        {
            var headerModel = new TopNavigationModel
            {
                TopNavigation = _topNavigationRepository.GetNavigationObject(SitecoreItemReferencesFields.NavigationElement)               
            };

            return headerModel;
        }
    }
}