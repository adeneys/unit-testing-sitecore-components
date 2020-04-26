using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using UnitTestingSitecoreComponents.Web.Models;
using UnitTestingSitecoreComponents.Web.Taxonomy;

namespace UnitTestingSitecoreComponents.Web.RenderingModels
{
    public class EntryCategoriesRenderingModel : RenderingModel
    {
        private IEntryTaxonomy _entryTaxonomy;

        public IEnumerable<Category> Categories { get; set; }

        public EntryCategoriesRenderingModel(IEntryTaxonomy entryTaxonomy)
        {
            if (entryTaxonomy == null)
                throw new ArgumentNullException(nameof(entryTaxonomy));

            _entryTaxonomy = entryTaxonomy;
        }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            Categories = _entryTaxonomy.GetCategories(Item);
        }
    }
}
