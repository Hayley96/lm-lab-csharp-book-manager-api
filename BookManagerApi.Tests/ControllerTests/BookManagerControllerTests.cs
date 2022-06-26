﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using BookManagerApi.Controllers;
using BookManagerApi.Models;
using BookManagerApi.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BookManagerApi.Tests;

public class BookManagerControllerTests
{
    private BookManagerController? _controller;
    private Mock<IBookManagementService>? _mockBookManagementService;

    [SetUp]
    public void Setup()
    {
        //Arrange
        _mockBookManagementService = new Mock<IBookManagementService>();
        _controller = new BookManagerController(_mockBookManagementService.Object);
    }

    [Test]
    public void GetBooks_Returns_AllBooks()
    {
        //Arange
        _mockBookManagementService!.Setup(b => b.GetAllBooks()).Returns(GetTestBooks());

        //Act
        var result = _controller!.GetBooks();

        //Assert
        result.Should().BeOfType(typeof(ActionResult<IEnumerable<Book>>));
        result.Value.Should().BeEquivalentTo(GetTestBooks());
        result.Value!.Count().Should().Be(3);
    }

    [Test]
    public void GetBookById_Returns_CorrectBook()
    {
        //Arrange
        var testBookFound = GetTestBooks().FirstOrDefault();
        _mockBookManagementService!.Setup(b => b.FindBookById(1)).Returns(testBookFound!);

        //Act
        var result = _controller!.GetBookById(1);

        //Assert
        result.Should().BeOfType(typeof(ActionResult<Book>));
        result.Value.Should().Be(testBookFound);
    }

    [Test]
    public void UpdateBookById_Updates_Correct_Book()
    {
        //Arrange
        long existingBookId = 3;
        Book existingBookFound = GetTestBooks()
            .FirstOrDefault(b => b.Id.Equals(existingBookId))!;

        var bookUpdates = new Book() { Id = 3, Title = "Book Three", Description = "I am updating this for Book Three", Author = "Person Three", Genre = Genre.Education };

        _mockBookManagementService!.Setup(b => b.FindBookById(existingBookId)).Returns(existingBookFound!);

        //Act
        var result = _controller!.UpdateBookById(existingBookId, bookUpdates);

        //Assert
        result.Should().BeOfType(typeof(NoContentResult));
    }

    [Test]
    public void AddBook_Creates_A_Book()
    {
        //Arrange
        var newBook = new Book() { Id = 4, Title = "Book Four", Description = "This is the description for Book Four", Author = "Person Four", Genre = Genre.Education };

        _mockBookManagementService!.Setup(b => b.Create(newBook)).Returns(newBook);

        //Act
        var result = _controller!.AddBook(newBook);

        //Assert
        result.Should().BeOfType(typeof(ActionResult<Book>));
    }

    private static List<Book> GetTestBooks()
    {
        return new List<Book>
        {
            new Book() { Id = 1, Title = "Book One", Description = "This is the description for Book One", Author = "Person One", Genre = Genre.Education },
            new Book() { Id = 2, Title = "Book Two", Description = "This is the description for Book Two", Author = "Person Two", Genre = Genre.Fantasy },
            new Book() { Id = 3, Title = "Book Three", Description = "This is the description for Book Three", Author = "Person Three", Genre = Genre.Thriller },
        };
    }

    [Test]
    public void DeleteBookById_Deletes_The_Matching_Book()
    {
        long existingBookId = 3;
        _mockBookManagementService!.Setup(b => b.BookExists(existingBookId)).Returns(true);

        var result = _controller!.DeleteBookById(existingBookId);

        result.Should().BeOfType(typeof(ActionResult<Book>));
    }

    [Test]
    public void Result_Should_Return_NotFound_With_Custom_Message_When_Book_With_Id_Not_Found()
    {
        long existingBookId = 3;
        _mockBookManagementService!.Setup(b => b.BookExists(existingBookId)).Returns(false);

        var result = BookManagerController.Result(HttpStatusCode.NotFound, $"Book with id {existingBookId} not found in our books...Please try again") as ContentResult;

        Assert.NotNull(result);
        Assert.AreEqual($"Status Code: 404 NotFound: Book with id {existingBookId} not found in our books...Please try again", result!.Content);
    }

    [Test]
    public void Result_Should_Return_BadRequest_With_Custom_Message_When_User_Wants_To_Add_A_Book_With_An_Id_That_Already_Exists()
    {
        new Book() { Id = 1, Title = "Book One", Description = "This is the description for Book One", Author = "Person One", Genre = Genre.Education };
        long newbookid = 1;
        _mockBookManagementService!.Setup(b => b.BookExists(newbookid)).Returns(true);

        var result = BookManagerController.Result(HttpStatusCode.BadRequest, $"A Book with id {newbookid} already exists...Please try again") as ContentResult;

        Assert.NotNull(result);
        Assert.AreEqual($"Status Code: 400 BadRequest: A Book with id {newbookid} already exists...Please try again", result!.Content);
    }
}