using NSubstitute;
using Sitecore.Abstractions;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Linq;
using UnitTest.Comparers;
using UnitTestingSitecoreComponents.Web.Models;
using UnitTestingSitecoreComponents.Web.Taxonomy;
using Xunit;

namespace UnitTest.Taxonomy
{
    public class EntryTaxonomyTests
    {
        [Fact]
        public void Ctor_LinkManagerIsNull_Throws()
        {
            // arrange
            Action sutAction = () => new EntryTaxonomy(null);

            // act, assert
            var ex = Assert.Throws<ArgumentNullException>(sutAction);
            Assert.Equal("linkManager", ex.ParamName);
        }

        [Fact]
        public void GetCategories_ItemIsNull_ReturnsEmpty()
        {
            // arrange
            var linkManager = Substitute.For<BaseLinkManager>();
            var sut = new EntryTaxonomy(linkManager);

            // act
            var results = sut.GetCategories(null);

            // assert
            Assert.Empty(results);
        }

        [Fact]
        public void GetCategories_NoCategories_ReturnsEmpty()
        {
            // arrange
            var entryItem = CreateItem();
            SetItemField(entryItem, "Category", "");

            var linkManager = Substitute.For<BaseLinkManager>();
            var sut = new EntryTaxonomy(linkManager);

            // act
            var results = sut.GetCategories(entryItem);

            // assert
            Assert.Empty(results);
        }

        [Fact]
        public void GetCategories_HasCategories_ReturnsCategories()
        {
            // arrange
            var database = Substitute.For<Database>();

            var cat1 = CreateItem(database);
            SetItemField(cat1, "Title", "cat1");

            var cat2 = CreateItem(database);
            SetItemField(cat2, "Title", "cat2");

            var entryItem = CreateItem(database);
            SetItemField(entryItem, "Category", $"{cat1.ID}|{cat2.ID}");

            var linkManager = Substitute.For<BaseLinkManager>();
            linkManager.GetItemUrl(cat1).Returns("link1");
            linkManager.GetItemUrl(cat2).Returns("link2");

            var categories = new[]
            {
                new Category { Title = "cat1", Url = "link1" },
                new Category { Title = "cat2", Url = "link2" }
            };

            var sut = new EntryTaxonomy(linkManager);

            // act
            var results = sut.GetCategories(entryItem);

            // assert
            Assert.Equal(categories, results.ToArray(), new CategoryComparer());
        }

        /// <summary>
        /// Create a mocked <see cref="Item" />.
        /// </summary>
        /// <param name="database">The mocked database to use for the mocked item. If null, a new database mock will be used.</param>
        /// <returns>The mocked item.</returns>
        private Item CreateItem(Database database = null)
        {
            var db = database ?? Substitute.For<Database>();

            var item = Substitute.For<Item>(ID.NewID, ItemData.Empty, db);
            var fields = Substitute.For<FieldCollection>(item);
            item.Fields.Returns(fields);

            db.GetItem(item.ID).Returns(item);
            db.GetItem(item.ID.ToString()).Returns(item);

            return item;
        }

        /// <summary>
        /// Mock a field and add it to a mocked item.
        /// </summary>
        /// <param name="item">The mocked item to add the field to.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="fieldValue">The value of the field.</param>
        private void SetItemField(Item item, string fieldName, string fieldValue)
        {
            item[fieldName].Returns(fieldValue);

            var field = Substitute.For<Field>(ID.NewID, item);
            field.Database.Returns(item.Database);
            field.Value = fieldValue;
            item.Fields[fieldName].Returns(field);
        }
    }
}
