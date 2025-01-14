﻿using BookManagerApi.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookManagerApi.Data;

namespace BookManagerApi.Services
{
    public class BookManagementService : IBookManagementService
	{
        private readonly ModelsContext _context;

        public BookManagementService(ModelsContext context)
        {
            _context = context;
        }


        public List<Book> GetAllBooks()
        {
            var books = _context.Books!
                        .Include(b => b.Author)
                        .ToList();
            return books;
        }

        public Book Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(long id, Book book)
        {
            var existingBookFound = FindBookById(id);

            existingBookFound.Title = book.Title;
            existingBookFound.Description = book.Description;
            existingBookFound.Author = book.Author;
            existingBookFound.Genre = book.Genre;

            _context.SaveChanges();
            return book;
        }

        public Book Delete(long id)
        {
            var existingBookFound = FindBookById(id);
            _context.Remove(_context.Books!.Single(b => b.Id.Equals(existingBookFound.Id)));
            _context.SaveChanges();
            return existingBookFound;
        }

        public Book FindBookById(long id)
        {
            var book = _context.Books!.Find(id);
            return book!;
        }

        public bool BookExists(long id)
        {
            return _context.Books!.Any(b => b.Id == id);
        }
    }
}