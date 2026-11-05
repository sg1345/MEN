
using System.ComponentModel.DataAnnotations;

using static MEN.GCommon.EntityValidation.WorkoutTemplate;

namespace MEN.Data.Models
{
    public class WorkoutTemplate
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public virtual ICollection<TemplateItem> TemplateItems { get; set; } = new List<TemplateItem>();
    }
}
