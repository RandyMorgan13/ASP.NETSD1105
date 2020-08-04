using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; //Entity Framework talks to the databases//

namespace DailyBlogger.Models
{
    public class BlogContext : DbContext //DbContext-Class provided by Entity Framework to connect to the Database, handles all little details//
    {
        public DbSet<BlogPost> blogPost { get; set; } //BlogPost-Table that we're working with. DbSet represents our BlogPost Table//
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)//The Constructor for our class. Accepts parameter "options" of type "DbContext Options" Connects BlogContext to ConectionString,
        {

        }
    }
}
