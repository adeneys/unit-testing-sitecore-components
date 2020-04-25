using System;
using UnitTestingSitecoreComponents.Web.Models;
using Xunit;

namespace UnitTest.Models
{
    public class EntryCategoriesTests
    {
        [Fact]
        public void Ctor_CategoriesIsNull_ThrowsException()
        {
            // arrange
            Action sutAction = () => new EntryCategories(null);

            // act, assert
            var ex = Assert.Throws<ArgumentNullException>(sutAction);
            Assert.Equal("categories", ex.ParamName);
        }

        [Fact]
        public void Ctor_WhenCalled_SetsProperties()
        {
            // arrange
            var categories = new[]
            {
                new Category { Title = "cat1", Url = "link1" },
                new Category { Title = "cat2", Url = "link2" }
            };


            // act
            var sut = new EntryCategories(categories);

            // assert
            Assert.Equal(categories, sut.Categories);
        }
    }
}
