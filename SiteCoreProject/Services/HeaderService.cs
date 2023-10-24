using SiteCoreProject.Models;
using SiteCoreProject.Interfaces;
using SiteCoreProject.Fields;

namespace SiteCoreProject.Services
{
    public class HeaderService : IHeaderService
    {
        private readonly IMainRepository _mainRepository;

        public HeaderService(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        public HeaderModel GetHeaderData()
        {
            var headerModel = new HeaderModel
            {
                LogoText = _mainRepository.GetRenderField(HeaderFields.Title),
                SubLogoText = _mainRepository.GetRenderField(HeaderFields.SubTitle),
                QuoteText = _mainRepository.GetRenderField(HeaderFields.QuoteTitle)
            };
            
            return headerModel;
        }
    }
}