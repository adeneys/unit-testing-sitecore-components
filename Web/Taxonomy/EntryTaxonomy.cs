using Sitecore.Abstractions;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingSitecoreComponents.Web.Models;

namespace UnitTestingSitecoreComponents.Web.Taxonomy
{
    public class EntryTaxonomy
    {
        private BaseLinkManager _linkManager;

        public EntryTaxonomy(BaseLinkManager linkManager)
        {
            if (linkManager == null)
                throw new ArgumentNullException(nameof(linkManager));

            _linkManager = linkManager;
        }

        public IEnumerable<Category> GetCategories(Item entryItem)
        {
            if (entryItem == null)
                return Enumerable.Empty<Category>();

            var categoryField = (MultilistField)entryItem.Fields["Category"];
            var items = categoryField?.GetItems() ?? Enumerable.Empty<Item>();
            var categories = from item in items
                             select new Category
                             {
                                 Title = item["Title"],
                                 Url = _linkManager.GetItemUrl(item)
                             };

            return categories;
        }
    }
}
