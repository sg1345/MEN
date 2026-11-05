using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static MEN.GCommon.EntityValidation.WorkoutItem;

namespace MEN.Data.Models
{
    public class TemplateItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TemplateId { get; set; }

        [ForeignKey(nameof(Exercise))]
        public Guid ExerciseId { get; set; }

        public int DefaultSets { get; set; } = TemplateItemDefaultSets;

        public Exercise? Exercise { get; set; }
    }
}
