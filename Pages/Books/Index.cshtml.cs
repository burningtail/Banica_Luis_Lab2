using Banica_Luis_Lab2.Models;
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

        public IList<Book> Book { get; set; }
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }

        public async Task OnGetAsync()
        {

                Book = await _context.Book
                 .Include(b => b.Publisher)
                    .ToListAsync();
            }
        }
    }