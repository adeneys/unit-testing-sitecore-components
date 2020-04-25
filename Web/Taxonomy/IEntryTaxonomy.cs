using Sitecore.Data.Items;
using System.Collections.Generic;
using UnitTestingSitecoreComponents.Web.Models;

namespace UnitTestingSitecoreComponents.Web.Taxonomy
{
    public interface IEntryTaxonomy
    {
        IEnumerable<Category> GetCategories(Item entryItem);
    }
}