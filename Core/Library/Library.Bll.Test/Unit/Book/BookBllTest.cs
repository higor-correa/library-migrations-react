using FluentAssertions;
using Library.Bll.Book;
using Library.Bll.Book.Interfaces;
using Library.Bll.Book.Validators.Interface;
using Library.Bll.Exceptions;
using Library.Bll.Test.Builder;
using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Bll.Test.Unit.Book
{
    public class BookBllTest
    {
        private BookBll _bookBll;
        private IBookRepository _repository;
        private IPublishierRepository _publishierRepository;
        private IBookPublishValidator _bookPublishValidator;
        private IPublishBookBll _publishBookBll;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IBookRepository>();
            _publishierRepository = Substitute.For<IPublishierRepository>();
            _bookPublishValidator = Substitute.For<IBookPublishValidator>();
            _publishBookBll = Substitute.For<IPublishBookBll>();

            _bookBll = new BookBll(_repository, _publishierRepository, _bookPublishValidator, _publishBookBll);
        }

        [TestCase]
        public void Should_Call_Unpublish()
        {
            var publisher = new PublisherBuilder().Build();
            var book = new BookBuilder().WithPublisher(publisher).WithPublishDate(DateTime.Now).Build();

            _repository.Get(Arg.Is(book.Id)).Returns(new List<BookEntity> { book }.AsQueryable());

            _bookBll.UnPublish(book.Id);

            book.Publishier.Should().BeNull();
            book.PublishDate.Should().BeNull();
        }

        [TestCase]
        public void Should_Validate_Unpublish()
        {
            var publisher = new PublisherBuilder().Build();
            var book = new BookBuilder().WithPublisher(publisher).WithPublishDate(DateTime.Now).Build();

            Action act = () => _bookBll.UnPublish(book.Id);

            act.Should()
               .Throw<EntityNotFoundException>()
               .WithMessage(new EntityNotFoundException($"Book ({book.Id})").Message);
        }
    }
}
