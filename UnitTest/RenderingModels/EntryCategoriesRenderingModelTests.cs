using Sitecore.Mvc.Presentation;
using UnitTestingSitecoreComponents.Web.RenderingModels;
using Xunit;

namespace UnitTest.RenderingModels
{
    public class EntryCategoriesRenderingModelTests
    {
        [Fact(Skip = "Need to mock items")]
        public void Initialize_RenderingItemHasNoCategories_CategoriesIsEmpty()
        {
            // arrange
            var rendering = new Rendering();
            //rendering.Item = ??;

            var sut = new EntryCategoriesRenderingModel();

            // act
            sut.Initialize(rendering);

            // assert
            Assert.Empty(sut.CategoryItems);
        }

        [Fact(Skip = "Need to mock items")]
        public void Initialize_RenderingItemHasCategories_SetsCategoryItemsFromRenderingItem()
        {
            // arrange
            var rendering = new Rendering();
            //rendering.Item = ??;

            var sut = new EntryCategoriesRenderingModel();

            // act
            sut.Initialize(rendering);

            // assert
            //Assert.Equal(new[] { cat1, cat2 }, sut.CategoryItems);
        }
    }
}
