using System;
using System.Web.Mvc;
using UnitTestingSitecoreComponents.Web.Models;
using UnitTestingSitecoreComponents.Web.Taxonomy;

namespace UnitTestingSitecoreComponents.Web.Controllers
{
    public class EntryCategoriesController : Controller
    {
        private IEntryTaxonomy _entryTaxonomy;

        public EntryCategoriesController(IEntryTaxonomy entryTaxonomy)
        {
            if (entryTaxonomy == null)
                throw new ArgumentNullException(nameof(entryTaxonomy));

            _entryTaxonomy = entryTaxonomy;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = _entryTaxonomy.GetCategories(Sitecore.Context.Item);
            var model = new EntryCategories(categories);

            return PartialView("/Views/Partial/EntryCategories.cshtml", model);
        }
    }
}
