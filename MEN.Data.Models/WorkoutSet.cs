using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEN.Data.Models
{
    public class WorkoutSet
    {
        [Key]
        public Guid Id { get; set; }

        public Guid WorkoutLogId { get; set; }
        public virtual WorkoutLog WorkoutLog { get; set; } = null!;

        [ForeignKey(nameof(Exercise))]
        public Guid ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; } = null!;

        [Required]
        public int SetNumber { get; set; }

        public int? Reps { get; set; }

        public double? Weight { get; set; }

        public double? Distance { get; set; }
        
        public TimeSpan? Duration { get; set; }

        [Required]
        public bool IsCompleted { get; set; } = false;

        
    }
}
