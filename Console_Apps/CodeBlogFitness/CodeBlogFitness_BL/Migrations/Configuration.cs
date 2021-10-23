namespace CodeBlogFitness_BL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeBlogFitness_BL.Controller.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //TODO: Запомнить, что на прод так нельзя
            ContextKey = "CodeBlogFitness_BL.Controller.FitnessContext";
        }

        protected override void Seed(CodeBlogFitness_BL.Controller.FitnessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
