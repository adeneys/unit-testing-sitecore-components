using System.Web.Mvc;
using UnitTestingSitecoreComponents.Web.Controllers;
using UnitTestingSitecoreComponents.Web.Models;
using Xunit;

namespace UnitTest.Controllers
{
    public class EntryCategoriesControllerTests
    {
        [Fact(Skip = "Need to mock items")]
        public void Index_WhenCalled_ReturnsPartialView()
        {
            // arrange
            //Sitecore.Context.Item = ??;
            var sut = new EntryCategoriesController();

            // act
            var result = sut.Index();

            // assert
            Assert.IsType<PartialViewResult>(result);

            var partialViewResult = result as PartialViewResult;
            Assert.Equal("/Views/Partial/EntryCategories.cshtml", partialViewResult.ViewName);
        }

        [Fact(Skip = "Need to mock items")]
        public void Index_ContextItemHasNoCategories_ModelCategoriesIsEmpty()
        {
            // arrange
            //Sitecore.Context.Item = ??;
            var sut = new EntryCategoriesController();

            // act
            var result = sut.Index();
            var partialViewResult = result as PartialViewResult;

            // assert
            Assert.IsType<EntryCategories>(partialViewResult.Model);

            var model = partialViewResult.Model as EntryCategories;
            Assert.Empty(model.Categories);
        }

        [Fact(Skip = "Need to mock items")]
        public void Index_ContextItemHasCategories_IncludesCategoriesInModel()
        {
            // arrange
            //Sitecore.Context.Item = ??;
            var sut = new EntryCategoriesController();

            // act
            var result = sut.Index();
            var partialViewResult = result as PartialViewResult;

            // assert
            Assert.IsType<EntryCategories>(partialViewResult.Model);

            var model = partialViewResult.Model as EntryCategories;
            //Assert.Equal(new[] { cat1, cat2 }, model.CategoryItems);
        }
    }
}
