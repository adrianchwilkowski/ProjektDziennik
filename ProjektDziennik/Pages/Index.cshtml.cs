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
        public List<User> UserInfo { get; set; } = default!;
        public List<User> UserInfo2 { get; set; } = default!;
        public List<string> Roles = new List<string>();
        public string name { get; set; }
        public string surname { get; set; }

        public async Task OnGetAsync()
        {
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                name = "Student name";
                surname = "Student surname";
                Roles.Add("Admin");
                Roles.Add("Student");
                Roles.Add("Teacher");
                UserInfo = new List<User>();
                UserInfo2 = new List<User>();
                Mark = await _context.Marks
                    .Include(s => s.Teacher)
                    .ToListAsync();

                User StudentAdd;
                User TeacherAdd;
                for (int i = 0; i < Mark.Count; i++)
                {
                    StudentAdd = await _context.Users
                    .Where(u => u.Id == Mark[i].StudentId)
                    .FirstOrDefaultAsync();
                    UserInfo.Add(StudentAdd);

                    TeacherAdd = await _context.Users
                    .Where(u => u.Id == Mark[i].TeacherId)
                    .FirstOrDefaultAsync();
                    UserInfo2.Add(TeacherAdd);
                }

            }
            else if (_httpContextAccessor.HttpContext.User.IsInRole("Student"))
            {
                name = "Teacher name";
                surname = "Teacher surname";
                UserInfo = new List<User>();
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Roles.Add("Student");
                Mark = await _context.Marks
                .Where(e => e.StudentId == userId)
                //.Include(s => s.Teacher)
                .ToListAsync();
                User TeacherAdd;
                for (int i = 0; i < Mark.Count; i++)
                {
                    TeacherAdd = await _context.Users
                    .Where(u => u.Id == Mark[i].TeacherId)
                    .FirstOrDefaultAsync();
                    UserInfo.Add(TeacherAdd);
                }

            }
            else if (_httpContextAccessor.HttpContext.User.IsInRole("Teacher"))
            {
                name = "Student name";
                surname = "Student surname";
                UserInfo = new List<User>();
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Roles.Add("Teacher");
                Mark = await _context.Marks
                .Where(e => e.TeacherId == userId)
                //.Include(s => s.Teacher)
                .ToListAsync();
                User StudentAdd;
                for (int i = 0; i < Mark.Count; i++)
                {
                    StudentAdd = await _context.Users
                    .Where(u => u.Id == Mark[i].StudentId)
                    .FirstOrDefaultAsync();
                    UserInfo.Add(StudentAdd);
                }

            }

        }
    }
}
