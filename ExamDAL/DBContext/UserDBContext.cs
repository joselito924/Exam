using ExamModel;
using Microsoft.EntityFrameworkCore;

namespace ExamDAL
{
    public class UserDBContext : DbContext
    {
        public UserDBContext()
        {
        }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseLazyLoadingProxies();

        public DbSet<tblUserProfile> UserProfiles { get; set; }
        public DbSet<tblGender> Genders { get; set; }
    }
}
