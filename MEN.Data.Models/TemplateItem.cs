using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static MEN.GCommon.EntityValidation.WorkoutItem;

namespace MEN.Data.Models
{
    public class TemplateItem
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(WorkoutTemplate))]
        public Guid WorkoutTemplateId { get; set; }
        public virtual WorkoutTemplate WorkoutTemplate { get; set; } = null!;

        [ForeignKey(nameof(Exercise))]
        public Guid ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; } = null!;

        public int DefaultSets { get; set; } = TemplateItemDefaultSets;


    }
}
