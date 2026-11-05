using MEN.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;
using static MEN.GCommon.EntityValidation.Exercise;

namespace MEN.Data.Models
{
    public class Exercise
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Category Category { get; set; }

        [Required]
        public ExersiceType ExersiceType { get; set; }

        [Required]
        public bool IsCustom { get; set; } = false;
    }
}
