using System.Collections.Generic;
using UnitTestingSitecoreComponents.Web.Models;

namespace UnitTest.Comparers
{
    class CategoryComparer : IEqualityComparer<Category>
    {
        public bool Equals(Category x, Category y)
        {
            return
                x.Title.Equals(y.Title) &&
                x.Url.Equals(y.Url);
        }

        public int GetHashCode(Category obj)
        {
            return
                obj.Title.GetHashCode() +
                obj.Url.GetHashCode();
        }
    }
}
