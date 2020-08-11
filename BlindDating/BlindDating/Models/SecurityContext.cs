using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.CodeAnalysis.Options;
using System.Security.Cryptography.X509Certificates;

namespace BlindDating.Models
{
    public class SecurityContext : IdentityDbContext
    {
        public SecurityContext()
        {
        }
        public SecurityContext(DbContextOptions<SecurityContext> options)
             : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-EQ5TUGB\\SQLEXPRESS;Database=BlindDating;Trusted_Connection=True;");
            }
        }
    }
}
