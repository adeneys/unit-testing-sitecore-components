using System;
using System.Collections.Generic;

namespace UnitTestingSitecoreComponents.Web.Models
{
    public class EntryCategories
    {
        public IEnumerable<Category> Categories { get; }

        public EntryCategories(IEnumerable<Category> categories)
        {
            if (categories == null)
                throw new ArgumentNullException(nameof(categories));

            Categories = categories;
        }
    }
}
