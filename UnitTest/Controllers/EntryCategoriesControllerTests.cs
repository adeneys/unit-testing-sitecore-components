using NSubstitute;
using Sitecore.Data.Items;
using System;
using System.Linq;
using System.Web.Mvc;
using UnitTest.Comparers;
using UnitTestingSitecoreComponents.Web.Controllers;
using UnitTestingSitecoreComponents.Web.Models;
using UnitTestingSitecoreComponents.Web.Taxonomy;
using Xunit;

namespace UnitTest.Controllers
{
    public class EntryCategoriesControllerTests
    {
        [Fact]
        public void Ctor_TaxonomyIsNull_ThrowsException()
        {
            // arrange
            Action sutAction = () => new EntryCategoriesController(null);

            // act, assert
            var ex = Assert.Throws<ArgumentNullException>(sutAction);
            Assert.Equal("entryTaxonomy", ex.ParamName);
        }

        [Fact]
        public void Index_WhenCalled_ReturnsPartialView()
        {
            // arrange
            var taxonomy = Substitute.For<IEntryTaxonomy>();
            var sut = new EntryCategoriesController(taxonomy);

            // act
            var result = sut.Index();

            // assert
            Assert.IsType<PartialViewResult>(result);

            var partialViewResult = result as PartialViewResult;
            Assert.Equal("/Views/Partial/EntryCategories.cshtml", partialViewResult.ViewName);
        }

        [Fact]
        public void Index_NoCategories_ModelCategoriesIsEmpty()
        {
            // arrange
            var taxonomy = Substitute.For<IEntryTaxonomy>();
            var sut = new EntryCategoriesController(taxonomy);

            // act
            var result = sut.Index();
            var partialViewResult = result as PartialViewResult;

            // assert
            Assert.IsType<EntryCategories>(partialViewResult.Model);

            var model = partialViewResult.Model as EntryCategories;
            Assert.Empty(model.Categories);
        }

        [Fact]
        public void Index_HasCategories_IncludesCategoriesInModel()
        {
            // arrange
            var categories = new[]
            {
                new Category { Title = "cat1", Url = "link1" },
                new Category { Title = "cat2", Url = "link2" }
            };

            var taxonomy = Substitute.For<IEntryTaxonomy>();
            taxonomy.GetCategories(Arg.Any<Item>()).Returns(categories);

            var sut = new EntryCategoriesController(taxonomy);

            // act
            var result = sut.Index();
            var partialViewResult = result as PartialViewResult;

            // assert
            Assert.IsType<EntryCategories>(partialViewResult.Model);

            var model = partialViewResult.Model as EntryCategories;
            Assert.Equal(categories, model.Categories.ToArray(), new CategoryComparer());
        }
    }
}
