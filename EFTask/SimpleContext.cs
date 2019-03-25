﻿using System.Data.Entity;


using EFTask.Models;

namespace EFTask
{
    public class SimpleContext : DbContext
    {
        static SimpleContext()
        {
            Database.SetInitializer<SimpleContext>(new MyContextInitializer());
        }

        public SimpleContext() : base("DefaultConnection")
        { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.FirstName).HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.LastName).HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.FirstName).IsRequired();
        }
    }

    class MyContextInitializer : DropCreateDatabaseAlways<SimpleContext>
    {
        protected override void Seed(SimpleContext db)
        {
            User u1 = new User { FirstName = "Ivan", LastName = "Petrov", GroupId = 1, Position = "Leader" };
            User u2 = new User { FirstName = "Anton", LastName = "Pushkin", GroupId = 1, Position = "Member" };
            User u3 = new User { FirstName = "Igor", LastName = "Dyachenko", GroupId = 2, Position = "Member" };
            User u4 = new User { FirstName = "Denis", LastName = "Miroshnichenko", GroupId = 2, Position = "Leader" };
            User u5 = new User { FirstName = "Eduard", LastName = "Dobrovolskiy", GroupId = 2, Position = "Member" };
            User u6 = new User { FirstName = "Elisaveta", LastName = "Valkiryeva", GroupId = 3, Position = "Leader" };
            User u7 = new User { FirstName = "Katerina", LastName = "Massonova", GroupId = 3, Position = "Member" };
            User u8 = new User { FirstName = "Tamara", LastName = "Rybka", GroupId = 3, Position = "Member" };
            User u9 = new User { FirstName = "Oleg", LastName = "Kurnosov", GroupId = 4, Position = "Leader" };
            User u10 = new User { FirstName = "Viktor", LastName = "Kochubey", GroupId = 4, Position = "Member" };

            Group g1 = new Group { GroupName = "Group Alpha", LeaderId = 1 };
            Group g2 = new Group { GroupName = "Group Beta", LeaderId = 4 };
            Group g3 = new Group { GroupName = "Group Hamma", LeaderId = 6 };
            Group g4 = new Group { GroupName = "Group Omega", LeaderId = 9 };

            db.Users.Add(u1);
            db.Users.Add(u2);
            db.Users.Add(u3);
            db.Users.Add(u4);
            db.Users.Add(u5);
            db.Users.Add(u6);
            db.Users.Add(u7);
            db.Users.Add(u8);
            db.Users.Add(u9);
            db.Users.Add(u10);
            db.Groups.Add(g1);
            db.Groups.Add(g2);
            db.Groups.Add(g3);
            db.Groups.Add(g4);
            db.SaveChangesAsync();
        }
    }
}
