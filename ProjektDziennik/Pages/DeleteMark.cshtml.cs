using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektDziennik.Data;
using ProjektDziennik.Models;

namespace ProjektDziennik.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ProjektDziennik.Data.ApplicationDbContext _context;

        public DeleteModel(ProjektDziennik.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mark Mark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _context.Marks == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks.FirstOrDefaultAsync(m => m.Id == id);

            if (mark == null)
            {
                return NotFound();
            }
            else
            {
                Mark = mark;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _context.Marks == null)
            {
                return NotFound();
            }
            var mark = await _context.Marks.FindAsync(id);

            if (mark != null)
            {
                Mark = mark;
                _context.Marks.Remove(Mark);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
