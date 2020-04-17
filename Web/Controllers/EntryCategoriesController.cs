using Sitecore.Data.Fields;
using Sitecore.Data.Items;
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
            var model = new EntryCategories(categoryField?.GetItems() ?? Enumerable.Empty<Item>());

            return PartialView("/Views/Partial/EntryCategories.cshtml", model);
        }
    }
}
