using Sitecore.Data.Items;
using System;
using System.Collections.Generic;

namespace UnitTestingSitecoreComponents.Web.Models
{
    public class EntryCategories
    {
        public IEnumerable<Item> CategoryItems { get; }

        public EntryCategories(IEnumerable<Item> categoryItems)
        {
            if (categoryItems == null)
                throw new ArgumentNullException(nameof(categoryItems));

            CategoryItems = categoryItems;
        }
    }
}
