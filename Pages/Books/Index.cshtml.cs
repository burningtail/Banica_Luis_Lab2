﻿using Banica_Luis_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Banica_Luis_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Banica_Luis_Lab2.Data.Banica_Luis_Lab2Context _context;

        public IndexModel(Banica_Luis_Lab2.Data.Banica_Luis_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {

                Book = await _context.Book
                 .Include(b => b.Publisher)
                    .ToListAsync();
            }
        }
    }