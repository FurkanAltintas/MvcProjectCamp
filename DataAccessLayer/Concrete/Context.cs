using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Ability> Ability { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AdminRole> AdminRole { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Heading> Heading { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<ImageCategory> ImageCategory { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Writer> Writer { get; set; }
    }
}
