using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Entities;

namespace DatabaseContext
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }
            
            string adminPassword = "qwertyuiop";
            string userPassword = "asdfghjkl";

            var users = new User[]
            {
                new User{Name = "AdminUser", Login = "Admin", Password = HashPassword(adminPassword)},
                new User{Name = "NormalUser", Login = "User", Password = HashPassword(userPassword)},
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var roles = new Role[]
            {
                new Role{Id = 1, Code = "ADMIN", Name = "AdminRole", Description = "Role for administrators that can refresh data in DB"},
                new Role{Id = 2, Code = "USER", Name = "UserRole", Description = "Role for normal users. Just an example."}
            };
            foreach (Role role in roles)
            {
                context.Roles.Add(role);
            }
            context.SaveChanges();

            var userRoles = new UserRole[]
            {
                new UserRole{Id = 1, RoleId = 1, UserId = 1},
                new UserRole{Id = 2, RoleId = 2, UserId = 2}
            };
            foreach (UserRole userRole in userRoles)
            {
                context.UserRoles.Add(userRole);
            }
            context.SaveChanges();

            var tramLocations = new TramLocation[]
            {
                new TramLocation{Brigade = "1", LowFloor = true, FirstLine = "12", Lon = 21.3123, Lat = 21.3123, Time = DateTime.Now, Status = "Test status", Lines = "12, 14"}
            };
            foreach (TramLocation tramLocation in tramLocations)
            {
                context.TramLocations.Add(tramLocation);
            }
            context.SaveChanges();
        }

        private static string HashPassword(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var dataForHash = Encoding.ASCII.GetBytes(password);
            var hash = sha1.ComputeHash(dataForHash);
            string hashedPassword = Convert.ToBase64String(hash);
            return hashedPassword;
        }
    }
}
