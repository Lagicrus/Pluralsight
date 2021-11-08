using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            Book book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            
            var results = book.GetStats();

            Assert.Equal(85.6, results.Average);
            Assert.Equal(90.5, results.High);
            Assert.Equal(77.3, results.Low);
        }
    }
}