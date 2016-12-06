using Microsoft.AspNet.Identity.EntityFramework;
using Newsletter.Model.Topics;
using Newsletter.Model.Users;
using System.Data.Entity;

namespace Newsletter.DAL
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class NewsletterDbContext : IdentityDbContext<User>
    {
        [StructureMap.DefaultConstructor]
        public NewsletterDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<NewsletterDbContext>(new NewsletterDbInitializer());
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicSubType> TopicSubTypes { get; set; }

        public static NewsletterDbContext Create()
        {
            return new NewsletterDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany<Topic>(s => s.Topics)
                .WithMany(c => c.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("TopicId");
                    cs.ToTable("UserTopics");
                });
        }
    }
}
