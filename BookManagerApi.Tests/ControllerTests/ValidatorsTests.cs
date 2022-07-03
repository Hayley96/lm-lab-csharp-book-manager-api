using System.Net;
using BookManagerApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace BookManagerApi.Tests;

public class ValidatorsTests
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Result_Should_Return_NotFound_With_Custom_Message()
    {
        long existingAuthorId = 9;

        var result = Validators.Result(HttpStatusCode.NotFound, $"Author with id {existingAuthorId} not found in our authors...Please try again") as ContentResult;

        Assert.NotNull(result);
        Assert.AreEqual($"Status Code: 404 NotFound: Author with id {existingAuthorId} not found in our authors...Please try again", result!.Content);
    }

    [Test]
    public void Result_Should_Return_BadRequest_With_Custom_Message()
    {
        long newauthorid = 1;

        var result = Validators.Result(HttpStatusCode.BadRequest, $"A Author with id {newauthorid} already exists...Please try again") as ContentResult;

        Assert.NotNull(result);
        Assert.AreEqual($"Status Code: 400 BadRequest: A Author with id {newauthorid} already exists...Please try again", result!.Content);
    }
}