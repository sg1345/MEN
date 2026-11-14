using MEN.Data.Models;
using MEN.Data.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace MEN.Data
{
    public class MENDbContext : DbContext
    {
        public MENDbContext(DbContextOptions<MENDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Models.Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<Models.WorkoutTemplate> WorkoutTemplates { get; set; } = null!;
        public virtual DbSet<Models.TemplateItem> TemplateItems { get; set; } = null!;
        public virtual DbSet<Models.WorkoutLog> WorkoutLogs { get; set; } = null!;
        public virtual DbSet<Models.WorkoutSet> WorkoutSets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. WorkoutTemplate to TemplateItem (Cascade Delete)
            modelBuilder.Entity<TemplateItem>()
                .HasOne(ti => ti.WorkoutTemplate)
                .WithMany(wt => wt.TemplateItems)
                .HasForeignKey(ti => ti.WorkoutTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // 2. WorkoutLog to WorkoutSet (Cascade Delete)
            modelBuilder.Entity<WorkoutSet>()
                .HasOne(ws => ws.WorkoutLog)
                .WithMany(wl => wl.WorkoutSets)
                .HasForeignKey(ws => ws.WorkoutLogId)
                .OnDelete(DeleteBehavior.Cascade);

            // 3. Exercise to TemplateItem (Restrict Delete - protects templates)
            modelBuilder.Entity<TemplateItem>()
                .HasOne(ti => ti.Exercise)
                .WithMany()
                .HasForeignKey(ti => ti.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            // 4. Exercise to WorkoutSet (Restrict Delete - CRUCIAL: protects past workout history)
            modelBuilder.Entity<WorkoutSet>()
                .HasOne(ws => ws.Exercise)
                .WithMany()
                .HasForeignKey(ws => ws.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed default data
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise 
                { 
                    Id = Guid.Parse("4cd55940-61fc-4ebc-8994-fceaffa2e47b"), 
                    Name = "Bench Press", 
                    Category = Category.Chest, 
                    ExersiceType = ExersiceType.Weightlifting, 
                    IsCustom = false 
                },
                new Exercise 
                { 
                    Id = Guid.Parse("00f5d487-6088-4608-a6b3-bee3bab55bc0"),
                    Name = "Squat",
                    Category = Category.Legs,
                    ExersiceType = ExersiceType.Weightlifting,
                    IsCustom = false 
                },
                new Exercise 
                { 
                    Id = Guid.Parse("2888a3ec-1455-4083-98dd-cad9a1ca33d5"), 
                    Name = "Outdoor Run", 
                    Category = Category.Cardio, 
                    ExersiceType = ExersiceType.Distance, 
                    IsCustom = false 
                },
                new Exercise 
                { 
                    Id = Guid.Parse("af8629e2-17ce-41bd-9182-25f235d50e1f"), 
                    Name = "Bodyweight Pull-Ups", 
                    Category = Category.Back, 
                    ExersiceType = ExersiceType.Bodyweight, 
                    IsCustom = false 
                }
            );
        }
    }
}
