using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rc_tutors.Models;
using System.Collections.Generic;
using System.Linq;

namespace rc_tutors.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Message> Messages { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Sessions> Events { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            string STUDENT_ROLE_ID = "12345678-student-role-id";
            string TUTOR_ROLE_ID = "87654321-tutor-role-id";

            modelBuilder.Entity<Faculty>().HasData(new List<Faculty>
            {
                new Faculty { FacultyId = 1, Department = "Computer Science" },
                new Faculty { FacultyId = 2, Department = "Mathematics" },
            });

            modelBuilder.Entity<Modules>().HasData(new List<Modules>
            {
                new Modules { Id = 1, ModuleName = "Web Development", FacultyId = 1 },
                new Modules { Id = 2, ModuleName = "Database Management", FacultyId = 1 },
                new Modules { Id = 3, ModuleName = "Calculus", FacultyId = 2 },
                new Modules { Id = 4, ModuleName = "Statistics", FacultyId = 2 },
            });

            modelBuilder.Entity<Tutor>().HasData(new List<Tutor>
            {
                new Tutor { Id = 1, TutorImage = "https://placekitten.com/150/150", UserId = "tutor-user-id-1", ModuleId = 1 },
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Student",
                NormalizedName = "STUDENT",
                Id = STUDENT_ROLE_ID,
                ConcurrencyStamp = STUDENT_ROLE_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Tutor",
                NormalizedName = "TUTOR",
                Id = TUTOR_ROLE_ID,
                ConcurrencyStamp = TUTOR_ROLE_ID
            });

            var adminUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "rc_admin@gmail.com",
                EmailConfirmed = true,
                UserName = "rc_admin@gmail.com",
                NormalizedUserName = "RC_ADMIN@GMAIL.COM",
                FirstName = "AdminFirstName",
                LastName = "AdminLastName"
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "mypassword");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            var studentUsers = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "student-user-id-1",
                    Email = "student1@example.com",
                    EmailConfirmed = true,
                    UserName = "student1@example.com",
                    NormalizedUserName = "STUDENT1@EXAMPLE.COM",
                    FirstName = "Student1FirstName",
                    LastName = "Student1LastName"
                },
                new ApplicationUser
                {
                    Id = "student-user-id-2",
                    Email = "student2@example.com",
                    EmailConfirmed = true,
                    UserName = "student2@example.com",
                    NormalizedUserName = "STUDENT2@EXAMPLE.COM",
                    FirstName = "Student2FirstName",
                    LastName = "Student2LastName"
                }
            };

            foreach (var studentUser in studentUsers)
            {
                studentUser.PasswordHash = ph.HashPassword(studentUser, "studentpassword");
            }

            modelBuilder.Entity<ApplicationUser>().HasData(studentUsers);

            var studentRoleAssignments = studentUsers.Select(user => new IdentityUserRole<string>
            {
                RoleId = STUDENT_ROLE_ID,
                UserId = user.Id
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(studentRoleAssignments);

            var tutorUser = new ApplicationUser
            {
                Id = "tutor-user-id-1",
                Email = "tutor@example.com",
                EmailConfirmed = true,
                UserName = "tutor@example.com",
                NormalizedUserName = "TUTOR@EXAMPLE.COM",
                FirstName = "Bob",
                LastName = "Ye"
            };

            tutorUser.PasswordHash = ph.HashPassword(tutorUser, "tutorpassword");

            modelBuilder.Entity<ApplicationUser>().HasData(tutorUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = TUTOR_ROLE_ID,
                UserId = "tutor-user-id-1"
            });
        }
    }
}
