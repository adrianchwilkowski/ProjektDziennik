using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektDziennik.Models;

namespace ProjektDziennik.Data
{
    public static class SeedData
    {
        public enum Roles
        {
            Admin,
            Teacher,
            Student
        }
        public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new Role(Roles.Teacher.ToString()));
            await roleManager.CreateAsync(new Role(Roles.Student.ToString()));
        }
        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            List<string> roleList = new List<string>
            {
                Roles.Student.ToString(),
                Roles.Teacher.ToString(),
                Roles.Admin.ToString(),
            };
            //Seed Default User
            var defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Mukesh",
                LastName = "Murugan",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRolesAsync(defaultUser, roleList);
                    //await userManager.AddToRoleAsync(defaultUser, Roles.Teacher.ToString());
                    //await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
            }
        }
            public static async Task SeedAccounts(UserManager<User> userManager, RoleManager<Role> roleManager, ApplicationDbContext context)
        {
            List<Subject> subjects = new List<Subject>
            {
                new Subject {Id = Guid.NewGuid().ToString(),Name="mathematics"},
                new Subject {Id = Guid.NewGuid().ToString(),Name="physics"},
                new Subject {Id = Guid.NewGuid().ToString(),Name="chemistry"},
                new Subject {Id = Guid.NewGuid().ToString(),Name="geography"},
                new Subject {Id = Guid.NewGuid().ToString(),Name="P.E."},
                new Subject {Id = Guid.NewGuid().ToString(),Name="english"},
            };
            context.Subjects.AddRangeAsync(subjects);
            var teacher1 = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Teacher1",
                Email = "teacher1@gmail.com",
                FirstName = "teacher1",
                LastName = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != teacher1.Id))
            {
                var user = await userManager.FindByEmailAsync(teacher1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(teacher1, "Qazxsw%531");
                    await userManager.AddToRoleAsync(teacher1, Roles.Teacher.ToString());
                }
            }
            var teacher2 = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Teacher2",
                Email = "teacher2@gmail.com",
                FirstName = "teacher2",
                LastName = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != teacher2.Id))
            {
                var user = await userManager.FindByEmailAsync(teacher2.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(teacher2, "Qazxsw%531");
                    await userManager.AddToRoleAsync(teacher2, Roles.Teacher.ToString());
                }
            }
            var teacher3 = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Teacher3",
                Email = "teacher3@gmail.com",
                FirstName = "teacher3",
                LastName = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != teacher3.Id))
            {
                var user = await userManager.FindByEmailAsync(teacher3.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(teacher3, "Qazxsw%531");
                    await userManager.AddToRoleAsync(teacher3, Roles.Teacher.ToString());
                }
            }
            var defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "student",
                Email = "student@gmail.com",
                FirstName = "student",
                LastName = "student",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                StudentMarks = new List<Mark>
                {
                    new Mark
                    {
                        Value = 4,
                        Teacher = teacher1,
                        SubjectId=subjects[0].Id,
                    },
                    new Mark
                    {
                        Value= 5,
                        Teacher = teacher2,
                        SubjectId=subjects[2].Id,
                    },
                    new Mark
                    {
                        Value= 4,
                        Teacher = teacher3,
                        SubjectId=subjects[5].Id,
                    }
                }
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qazxsw%531");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                }
            }
            defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "student2",
                Email = "student2@gmail.com",
                FirstName = "student2",
                LastName = "student2",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                StudentMarks = new List<Mark>
                {
                    new Mark
                    {
                        Value= 3,
                        Teacher = teacher1,
                        SubjectId=subjects[2].Id,
                    },
                    new Mark
                    {
                        Value= 5,
                        Teacher = teacher2,
                        SubjectId=subjects[5].Id,
                    },
                    new Mark
                    {
                        Value= 4,
                        Teacher = teacher3,
                        SubjectId=subjects[1].Id,
                    }
                }
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qazxsw%531");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                }
            }
            defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "student3",
                Email = "student3@gmail.com",
                FirstName = "student3",
                LastName = "student3",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                StudentMarks = new List<Mark>
                {
                    new Mark
                    {
                        Value= 2,
                        Teacher = teacher1,
                        SubjectId=subjects[4].Id,
                    },
                    new Mark
                    {
                        Value= 3,
                        Teacher = teacher2,
                        SubjectId=subjects[5].Id,
                    },
                    new Mark
                    {
                        Value= 4,
                        Teacher = teacher3,
                        SubjectId=subjects[3].Id,
                    }
                }
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qazxsw%531");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                }
            }
            defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "student4",
                Email = "student4@gmail.com",
                FirstName = "student4",
                LastName = "student4",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                StudentMarks = new List<Mark>
                {
                    new Mark
                    {
                        Value= 1,
                        Teacher = teacher1,
                        SubjectId=subjects[0].Id,
                    },
                    new Mark
                    {
                        Value= 4,
                        Teacher = teacher2,
                        SubjectId=subjects[1].Id,
                    },
                    new Mark
                    {
                        Value= 5,
                        Teacher = teacher3,
                        SubjectId=subjects[2].Id,
                    }
                }
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qazxsw%531");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                }
            }
            defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "student5",
                Email = "student5@gmail.com",
                FirstName = "student5",
                LastName = "student5",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                StudentMarks = new List<Mark>
                {
                    new Mark
                    {
                        Value= 5,
                        Teacher = teacher1,
                        SubjectId=subjects[3].Id,
                    },
                    new Mark
                    {
                        Value= 5,
                        Teacher = teacher2,
                        SubjectId=subjects[1].Id,
                    },
                    new Mark
                    {
                        Value= 5,
                        Teacher = teacher3,
                        SubjectId=subjects[5].Id,
                    }
                }
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qazxsw%531");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                }
            }
            defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "student6",
                Email = "student6@gmail.com",
                FirstName = "student6",
                LastName = "student6",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                StudentMarks = new List<Mark>
                {
                    new Mark
                    {
                        Value= 3,
                        Teacher = teacher1,
                        SubjectId=subjects[4].Id,
                    },
                    new Mark
                    {
                        Value= 4,
                        Teacher = teacher2,
                        SubjectId=subjects[0].Id,
                    },
                    new Mark
                    {
                        Value= 3,
                        Teacher = teacher3,
                        SubjectId=subjects[5].Id,
                    }
                }
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qazxsw%531");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                }
            }
            defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "student7",
                Email = "student7@gmail.com",
                FirstName = "student7",
                LastName = "student7",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                StudentMarks = new List<Mark>
                {
                    new Mark
                    {
                        Value= 1,
                        Teacher = teacher1,
                        SubjectId=subjects[1].Id,
                    },
                    new Mark
                    {
                        Value= 2,
                        Teacher = teacher2,
                        SubjectId=subjects[2].Id,
                    },
                    new Mark
                    {
                        Value= 2,
                        Teacher = teacher3,
                        SubjectId=subjects[3].Id,
                    }
                }
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qazxsw%531");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                }
            }
        }

    }
}