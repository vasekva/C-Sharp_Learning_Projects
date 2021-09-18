using System;
using System.Data.Entity;
using CodeBlogFitness_BL.Model;

namespace CodeBlogFitness_BL.Controller
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("DBConnection") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
