using Microsoft.AspNetCore.Identity;

namespace ProjektDziennik.Models
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Mark> StudentMarks { get; set; }
        public virtual List<Mark> TeacherMarks { get; set; }
    }
}
