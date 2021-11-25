using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStats();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
        [Fact]
        public void NumbersMaxAt100()
        {
            InMemoryBook inMemoryBook = new InMemoryBook("");
            inMemoryBook.AddGrade(105);
            inMemoryBook.AddGrade(100);
            var stats = inMemoryBook.GetStats();
            Assert.Equal(stats.High, 100);
        }
        
        [Fact]
        public void Test1()
        {
            InMemoryBook inMemoryBook = new InMemoryBook("");
            inMemoryBook.AddGrade(89.1);
            inMemoryBook.AddGrade(90.5);
            inMemoryBook.AddGrade(77.3);
            
            var results = inMemoryBook.GetStats();

            Assert.Equal(85.6, results.Average);
            Assert.Equal(90.5, results.High);
            Assert.Equal(77.3, results.Low);
        }
    }
}