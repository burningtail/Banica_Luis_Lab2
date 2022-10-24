using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Banica_Luis_Lab2.Models;

namespace Banica_Luis_Lab2.Data
{
    public class Banica_Luis_Lab2Context : DbContext
    {
        public Banica_Luis_Lab2Context (DbContextOptions<Banica_Luis_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Banica_Luis_Lab2.Models.Book> Book { get; set; } = default!;
    }
}
