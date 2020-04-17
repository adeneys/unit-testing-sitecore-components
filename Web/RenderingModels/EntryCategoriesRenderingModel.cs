using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingSitecoreComponents.Web.RenderingModels
{
    public class EntryCategoriesRenderingModel : RenderingModel
    {
        public IEnumerable<Item> CategoryItems { get; set; }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            var categoryField = (MultilistField)Item.Fields["Category"];
            CategoryItems = categoryField?.GetItems() ?? Enumerable.Empty<Item>();
        }
    }
}
