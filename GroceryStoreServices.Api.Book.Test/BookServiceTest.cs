using AutoMapper;
using GenFu;
using GroceryStoreServices.Api.Book.Application;
using GroceryStoreServices.Api.Book.Model;
using GroceryStoreServices.Api.Book.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GroceryStoreServices.Api.Book.Test
{
    public class BookServiceTest
    {

        private IEnumerable<Library> GetTestData()
        {
            A.Configure<Library>()
            .Fill(x => x.Title).AsArticleTitle()
            .Fill(x => x.Id, () => { return Guid.NewGuid(); });


            var list = A.ListOf<Library>(30);
            list[0].Id = Guid.Empty;

            return list;
        }

        private Mock<LibraryContext> CreateContext()
        {
            var testData = GetTestData().AsQueryable();

            var dbSet = new Mock<DbSet<Library>>();
            dbSet.As<IQueryable<Library>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Library>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Library>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Library>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Library>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<Library>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Library>>().Setup(x => x.Provider)
                .Returns(new AsyncQueryProvider<Library>(testData.Provider));

            var context = new Mock<LibraryContext>();
            context.Setup(x => x.Library).Returns(dbSet.Object);
            return context;
        }

        [Fact]
        public async void GetBooks()
        {
            // Arange
            var mockContext = CreateContext();
            var mockMapper = new MapperConfiguration(configuration => 
            {
                configuration.AddProfile(new MappingTest());
            });


            var handler = new Query.Handler(mockMapper.CreateMapper(), mockContext.Object);

            var request = new Query.Execute();

            // Act
            var list = await handler.Handle(request, new System.Threading.CancellationToken());


            // Assert
            Assert.True(list.Any());
        }

        [Fact]
        public async void GetBookById()
        {
            // Arange
            var mockContext = CreateContext();
            var mockMapper = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MappingTest());
            });


            var handler = new QueryFilter.Handler(mockContext.Object, mockMapper.CreateMapper());

            var request = new QueryFilter.UniqueLibrary { BookId = Guid.Empty};

            // Act
            var book = await handler.Handle(request, new System.Threading.CancellationToken());

            // Assert
            Assert.NotNull(book);
        }


        [Fact]
        public async void CreateBook()
        {
            // Arane
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "BaseDatosLibro").Options;

            var context = new LibraryContext(options);


            var request = new New.Execute();
            request.Title = "Microservices book";
            request.AuthorBook = Guid.Empty;
            request.ReleaseDate = DateTime.Now;

            /// Act
            var handler = new New.Handler(context);
            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            /// Arange
            Assert.NotNull(result);
        }
    }
}

