using Sitecore.Mvc.Configuration;
using Sitecore.Mvc.Presentation;
using Sitecore.Pipelines;
using UnitTestingSitecoreComponents.Web.Presentation;

namespace UnitTestingSitecoreComponents.Web.Pipelines.Initialize
{
    public class RegisterModelLocator
    {
        public void Process(PipelineArgs args)
        {
            MvcSettings.RegisterObject<ModelLocator>(() => new ResolvingModelLocator());
        }
    }
}
