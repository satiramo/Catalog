using System;
using Xunit;

namespace BookCatalog.UnitTests
{
    public class Author_UnitTests
    {
        [Fact]
        public void Author_TestEmptyMiddleName()
        {
            var authorFullName = new Author("Vasya", "Pupkin", "").ToString();
            Assert.Equal("Vasya Pupkin", authorFullName);
        }

        [Fact]
        public void Author_TestNullMiddleName()
        {
            var authorFullName = new Author("Vasya", "Pupkin", null).ToString();
            Assert.Equal("Vasya Pupkin", authorFullName);
        }
    }
}
