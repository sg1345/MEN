
using System.ComponentModel.DataAnnotations;
using static MEN.GCommon.EntityValidation.WorkoutLog;

namespace MEN.Data.Models
{
    public class WorkoutLog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        [MaxLength(SessionNameMaxLength)]
        public string SessionName { get; set; } = SessionDefaultName;

        public TimeSpan? Duration { get; set; }

        public virtual ICollection<WorkoutSet> WorkoutSets { get; set; } 
            = new List<WorkoutSet>();

    }
}
