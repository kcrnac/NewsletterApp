using Microsoft.AspNet.Identity;
using Newsletter.Model.Topics;
using Newsletter.Model.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Newsletter.DAL
{
    public class NewsletterDbInitializer : CreateDatabaseIfNotExists<NewsletterDbContext>
    {
        protected override void Seed(NewsletterDbContext context)
        {
            context = InitialSeed(context);
            context.SaveChanges();

            base.Seed(context);
        }

        public static NewsletterDbContext InitialSeed(NewsletterDbContext context)
        {
            context.TopicSubTypes.AddOrUpdate(
                new TopicSubType() { Id = "454b8ba1-9d88-4274-a95f-b1d41bbfe3c6", Caption = "Politika", DateCreated = DateTime.Now, Type = TopicSubTypeEnum.Politics },
                new TopicSubType() { Id = "b892f212-f405-4e56-b26b-9d58b7270af8", Caption = "Glazba", DateCreated = DateTime.Now, Type = TopicSubTypeEnum.Music },
                new TopicSubType() { Id = "2b007329-889f-4f65-8372-9eaf36737165", Caption = "Sport", DateCreated = DateTime.Now, Type = TopicSubTypeEnum.Sport },
                new TopicSubType() { Id = "18218542-5c94-4266-a163-e1365b118b44", Caption = "Moda", DateCreated = DateTime.Now, Type = TopicSubTypeEnum.Fashion });

            var topic1 = new Topic() { Id = "416922f7-5f1c-49d6-aae4-79b85fec1cb6", Title = "Bon Jovi", Description = "Everything about Bon Jovi", DateCreated = DateTime.Now, TypeId = "b892f212-f405-4e56-b26b-9d58b7270af8" };
            var topic2 = new Topic() { Id = "410e9e3f-6543-43b2-9b3f-db4297a9dd39", Title = "Lionel Messi", Description = "Everything about Lionel Messi", DateCreated = DateTime.Now, TypeId = "2b007329-889f-4f65-8372-9eaf36737165" };
            var topic3 = new Topic() { Id = "fef60b3d-2cfd-4b19-b4d8-8306e0cf9313", Title = "Mirko Filipović", Description = "Everything about Mirko Filipoivić", DateCreated = DateTime.Now, TypeId = "2b007329-889f-4f65-8372-9eaf36737165" };

            context.Topics.AddOrUpdate(topic1, topic2, topic3);

            var passwordHash = new PasswordHasher().HashPassword("password");

            context.Users.AddOrUpdate(u => u.UserName,
                new User() { Id = new Guid("18218542-5c94-4266-a163-e1365b118b44").ToString(), UserName = "marin.mirkovic@some.com", PasswordHash = passwordHash, SecurityStamp = Guid.NewGuid().ToString("D"), FirstName = "Marin", LastName = "Mirković", Email = "marin.mirkovic@some.com", PhoneNumber = "+385987779542", DateCreated = DateTime.Now, Topics = new List<Topic>() { topic1, topic2 } },
                new User() { Id = new Guid("f5640b72-f772-4ed7-b6ee-3b5d2fbd821c").ToString(), UserName = "ivan.ivankovic@some.com", PasswordHash = passwordHash, SecurityStamp = Guid.NewGuid().ToString("D"), FirstName = "Ivan", LastName = "Ivanković", Email = "ivan.ivankovic@some.com", PhoneNumber = "+385951547811", DateCreated = DateTime.Now, Topics = new List<Topic>() { topic1, topic3 } }
                );

            return context;
        }
    }
}
