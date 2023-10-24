using System;
using System.Collections.Generic;
using System.Linq;
using SiteCoreProject.Interfaces;
using SiteCoreProject.Fields;
using SiteCoreProject.Models;

namespace SiteCoreProject.Services
{
    public class FooterService : IFooterService
    {
        private readonly IMainRepository _mainRepository;

        public FooterService(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        public FooterModel GetFooterData()
        {
            return new FooterModel
            {
                LogoText = _mainRepository.GetRenderField(FooterFields.FooterTitle),
                QuickLinksTitle = _mainRepository.GetRenderField(FooterFields.QuickLinksTitle),
                QuickLinksNavigationsList = GetQuickLinks(SitecoreItemReferencesFields.QuickLinksFolder),
                DataCentresTitle = _mainRepository.GetRenderField(FooterFields.DataCentresTitle),
                DataCentresNavigationsList = GetQuickLinks(SitecoreItemReferencesFields.DataCentresFolder),
                SocialMediaList = GetSocials(SitecoreItemReferencesFields.SocialMediaFolder),
                CopyRightText = _mainRepository.GetRenderField(FooterFields.CopyRightText),
                ContactSalesLabel = _mainRepository.GetRenderField(FooterFields.ContactSalesLabel),
                ContactSalesNumber = _mainRepository.GetRenderField(FooterFields.ContactSalesNumber),
                ContactSupportLabel = _mainRepository.GetRenderField(FooterFields.ContactSupportLabel),
                ContactSupportNumber = _mainRepository.GetRenderField(FooterFields.ContactSupportNumber),
                EmailLabel = _mainRepository.GetRenderField(FooterFields.EmailLabel),
                EmailAddress = _mainRepository.GetRenderField(FooterFields.EmailAddress),
                KeyLocationsTitle = _mainRepository.GetRenderField(FooterFields.KeyLocationsTitle),
                KeyLocationsNavigationsList = GetQuickLinks(SitecoreItemReferencesFields.KeyLocationsFolder)
            };
        }

        public List<BasicNavigations> GetQuickLinks(Guid field)
        {
            var children = _mainRepository.GetFolderElements(field);
            var getChildren = children.Select(c => GetTitles(c)).ToList();

            return getChildren;
        }


        public BasicNavigations GetTitles(Guid guid)
        {
            return new BasicNavigations
            {
                Title = _mainRepository.GetRenderField(guid, Fields.Fields.BasicTitle),
                Link = _mainRepository.GetRenderField(guid, Fields.Fields.BasicLink)
            };
        }

        public List<SocialMediaModel> GetSocials(Guid field)
        {
            var children = _mainRepository.GetFolderElements(field);
            var getChildren = children.Select(c => GetImageAndLink(c)).ToList();

            return getChildren;
        }

        public SocialMediaModel GetImageAndLink(Guid guid)
        {
            return new SocialMediaModel
            {
                Icon = _mainRepository.GetRenderField(guid, Fields.Socials.SocialImage),
                Link = _mainRepository.GetRenderField(guid, Fields.Socials.Link)
            };
        }
    }
}