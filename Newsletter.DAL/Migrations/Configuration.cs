namespace Newsletter.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsletterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NewsletterDbContext context)
        {
            context = NewsletterDbInitializer.InitialSeed(context);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
