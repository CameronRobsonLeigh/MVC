using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using SiteCoreProject.Fields;
using SiteCoreProject.Interfaces;
using SiteCoreProject.Models;

namespace SiteCoreProject.Repositorys
{
    public class TopNavigationRepository : ITopNavigationRepository
    {
        private readonly IMainRepository _mainRepository;

        public TopNavigationRepository(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        public List<Navigations> GetNavigationObject(Guid navigationFolder)
        {
            var getNavigationFolder = Sitecore.Context.Database.Items.GetItem(new ID(navigationFolder)).Children;
            var navigationElements = getNavigationFolder.Select(x => BuildNavigation(x)).ToList();

            return navigationElements;
        }

        public Navigations BuildNavigation(Item childItem)
        {
            List<Item> testing = new List<Item>();
            foreach (Sitecore.Data.Items.Item child in childItem.Children)
            {
                System.Console.WriteLine(child);
                testing.Add(child);
            }


            var hello = childItem.Children?.Select(x => x.ID.Guid);



            var test = new Navigations
            {
                Title = _mainRepository.ConvertHtmlString(childItem.Fields[Fields.NavigationFields.Title]?.Value),
                Link = _mainRepository.ConvertHtmlString(childItem.Fields[Fields.NavigationFields.Link]?.Value)
            };

            //var ids = _mainRepository.GetChildItems(childItem);
            //foreach (var subItem in ids)
            //{
               
            //    test.ChildItems.Add(GetSubNavigationItem(subItem));
                 
            //}

            return test;
        }


        //private SubNavigationItem GetSubNavigationItem(Guid guid)
        //{
        //    var subItem = new SubNavigationItem
        //    {
        //        Link = _mainRepository.GetRenderField(Fields.Fields.BasicLink),
        //        Title = _mainRepository.GetRenderField(Fields.Fields.BasicTitle),
        //    };

        //    var thirdLevel = _mainRepository.GetChildItems(guid);
        //    thirdLevel.ToList().ForEach(x => subItem.ChildItems.Add(GetNavigationItem(x)));

        //    return subItem;
        //}


    }
}