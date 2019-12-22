using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    public class FootballCommunityDbContext : DbContext
    {
        public FootballCommunityDbContext()
            : base("name=FootballCommunityDB") { }
        
        public static FootballCommunityDbContext Create()
        {
            return new FootballCommunityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<Fixture> fixtures { get; set; }
        public virtual DbSet<League> leagues { get; set; }
        public virtual DbSet<MyFixture> myFixtures { get; set; }
        public virtual DbSet<Prediction> predictions { get; set; }
        public virtual DbSet<PredictionType> predictionTypes { get; set; }
        public virtual DbSet<Team> teams { get; set; }
        public virtual DbSet<User> users { get; set; }
    }
}
