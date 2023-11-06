﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Nicolaie_Andreea_Lab2.Data.Nicolaie_Andreea_Lab2Context _context;

        public DetailsModel(Nicolaie_Andreea_Lab2.Data.Nicolaie_Andreea_Lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowings == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowings.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
