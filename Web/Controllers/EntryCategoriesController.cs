using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using System.Linq;
using System.Web.Mvc;
using UnitTestingSitecoreComponents.Web.Models;

namespace UnitTestingSitecoreComponents.Web.Controllers
{
    public class EntryCategoriesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var categoryField = (MultilistField)Sitecore.Context.Item.Fields["Category"];
            var items = categoryField?.GetItems() ?? Enumerable.Empty<Item>();
            var categories = from item in items
                             select new Category
                             {
                                 Title = item["Title"],
                                 Url = LinkManager.GetItemUrl(item)
                             };

            var model = new EntryCategories(categories);

            return PartialView("/Views/Partial/EntryCategories.cshtml", model);
        }
    }
}
