using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nicolaie_Andreea_Lab2.Data;
using Nicolaie_Andreea_Lab2.Models;

namespace Nicolaie_Andreea_Lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Nicolaie_Andreea_Lab2.Data.Nicolaie_Andreea_Lab2Context _context;

        public IndexModel(Nicolaie_Andreea_Lab2.Data.Nicolaie_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowings != null)
            {
                Borrowing = await _context.Borrowings
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
