using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Politiker.Infrastructure.Map;
using Politiker.Core.Entity;

namespace Politiker.Infrastructure
{
    public class MainContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Party> Parties { get; set; }

        public MainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AnswerMap());
            //modelBuilder.ApplyConfiguration(new CategoryMap());
            //modelBuilder.ApplyConfiguration(new PartyMap());
            //modelBuilder.ApplyConfiguration(new QuestionMap());
            var applyGenericMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);


            var mapTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType != null && x.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) && x.IsClass);
            foreach(var mapType in mapTypes)
            {
                var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(mapType.GenericTypeArguments[0]);
                applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(mapType) });

            }
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
