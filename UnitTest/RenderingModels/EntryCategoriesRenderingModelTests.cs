using NSubstitute;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Linq;
using UnitTestingSitecoreComponents.Web.Models;
using UnitTestingSitecoreComponents.Web.RenderingModels;
using UnitTestingSitecoreComponents.Web.Taxonomy;
using Xunit;

namespace UnitTest.RenderingModels
{
    public class EntryCategoriesRenderingModelTests
    {
        [Fact]
        public void Ctor_EntryTaxonomyIsNull_ThrowsException()
        {
            // arrange
            Action sutAction = () => new EntryCategoriesRenderingModel(null);

            // act, assert
            var ex = Assert.Throws<ArgumentNullException>(sutAction);
            Assert.Equal("entryTaxonomy", ex.ParamName);
        }

        [Fact]
        public void Initialize_RenderingItemHasNoCategories_CategoriesIsEmpty()
        {
            // arrange
            var rendering = new Rendering();
            rendering.Item = CreateItem();
            var entryTaxonomy = Substitute.For<IEntryTaxonomy>();

            var sut = new EntryCategoriesRenderingModel(entryTaxonomy);

            // act
            sut.Initialize(rendering);

            // assert
            Assert.Empty(sut.Categories);
        }

        [Fact]
        public void Initialize_RenderingItemHasCategories_SetsCategoryItemsFromRenderingItem()
        {
            // arrange
            var categories = new[]
            {
                new Category { Title = "cat1", Url = "link1" },
                new Category { Title = "cat2", Url = "link2" }
            };

            var rendering = new Rendering();
            rendering.Item = CreateItem();

            var entryTaxonomy = Substitute.For<IEntryTaxonomy>();
            entryTaxonomy.GetCategories(Arg.Any<Item>()).Returns(categories);

            var sut = new EntryCategoriesRenderingModel(entryTaxonomy);

            // act
            sut.Initialize(rendering);

            // assert
            Assert.Equal(categories, sut.Categories.ToArray());
        }

        private Item CreateItem()
        {
            var database = Substitute.For<Database>();
            return Substitute.For<Item>(ID.NewID, ItemData.Empty, database);
        }
    }
}
