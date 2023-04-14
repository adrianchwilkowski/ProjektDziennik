using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektDziennik.Data;
using ProjektDziennik.Models;

namespace ProjektDziennik.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public IndexModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public IList<Mark> Mark { get; set; } = default!;
        public IList<Mark> TeacherMark { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                Mark = await _context.Marks
                    .Include(s => s.Teacher)
                    .ToListAsync();
                TeacherMark = await _context.Marks
                    .Include(s => s.Student)
                    .ToListAsync();
            }
            else
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mark = await _context.Marks
                .Where(e => e.StudentId == userId)
                .Include(s => s.Teacher)
                .ToListAsync();
                TeacherMark = await _context.Marks
                .Where(e => e.TeacherId == userId)
                .Include(s => s.Student)
                .ToListAsync();
            }
            
        }
    }
}
