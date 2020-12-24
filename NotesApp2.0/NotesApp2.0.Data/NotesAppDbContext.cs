using Microsoft.EntityFrameworkCore;
using NotesApp2._0.Core;
using System;

namespace NotesApp2._0.Data
{
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext(DbContextOptions<NotesAppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Note> Notes { get; set; }
    }
}
