using System;
using UnitTestingSitecoreComponents.Web.Models;
using Xunit;

namespace UnitTest.Models
{
    public class EntryCategoriesTests
    {
        [Fact]
        public void Ctor_CategoryItemsIsNull_ThrowsException()
        {
            // arrange
            Action sutAction = () => new EntryCategories(null);

            // act, assert
            var ex = Assert.Throws<ArgumentNullException>(sutAction);
            Assert.Equal("categoryItems", ex.ParamName);
        }

        [Fact(Skip = "Need Items")]
        public void Ctor_WhenCalled_SetsProperties()
        {
            // arrange
            //var items = ??;

            // act
            //var sut = new EntryCategories(items);

            // assert
            //Assert.Equal(items, sut.CategoryItems);
        }
    }
}
