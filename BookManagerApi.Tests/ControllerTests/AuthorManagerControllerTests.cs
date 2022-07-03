using System.Collections.Generic;
using System.Linq;
using BookManagerApi.Controllers;
using BookManagerApi.Models;
using BookManagerApi.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BookManagerApi.Tests;

public class AuthorManagerControllerTests
{
    private AuthorManagerController? _controller;
    private Mock<IAuthorManagementService>? _mockAuthorManagementService;

    [SetUp]
    public void Setup()
    {
        //Arrange
        _mockAuthorManagementService = new Mock<IAuthorManagementService>();
        _controller = new AuthorManagerController(_mockAuthorManagementService.Object);
    }

    [Test]
    public void GetAuthors_Returns_AllAuthors()
    {
        //Arange
        _mockAuthorManagementService!.Setup(a => a.GetAllAuthors()).Returns(GetTestAuthors());

        //Act
        var result = _controller!.GetAuthors();

        //Assert
        result.Should().BeOfType(typeof(ActionResult<IEnumerable<Author>>));
        result.Value.Should().BeEquivalentTo(GetTestAuthors());
        result.Value!.Count().Should().Be(3);
    }

    [Test]
    public void GetAuthorById_Returns_CorrectAuthor()
    {
        //Arrange
        var testAuthorFound = GetTestAuthors().FirstOrDefault();
        _mockAuthorManagementService!.Setup(a => a.FindAuthorById(1)).Returns(testAuthorFound!);

        //Act
        var result = _controller!.GetAuthorById(1);

        //Assert
        result.Should().BeOfType(typeof(ActionResult<Author>));
        result.Value.Should().Be(testAuthorFound);
    }

    [Test]
    public void AddAuthor_Creates_A_Author()
    {
        //Arrange
        var newAuthor = new Author() { Id = 4, Name = "Book Four"};

        _mockAuthorManagementService!.Setup(a => a.Create(newAuthor)).Returns(newAuthor);

        //Act
        var result = _controller!.AddAuthor(newAuthor);

        //Assert
        result.Should().BeOfType(typeof(ActionResult<Author>));
    }

    private static List<Author> GetTestAuthors()
    {
        return new List<Author>
        {
            new Author() {Id = 1, Name = "Author One"},
            new Author() {Id = 2, Name = "Author Two"},
            new Author() {Id = 3, Name = "Author Three"}
        };
    }
}