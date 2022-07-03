using System;
using BookManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApi.Data
{
    public class ModelsContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ModelsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
    }
}