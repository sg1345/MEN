using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEN.GCommon
{
    public class EntityValidation
    {
        public static class Exercise
        {
            public const int NameMaxLength = 200;
        }

        public static class WorkoutSet
        {
            public const int SetNumberMinValue = 1;
            public const int SetNumberMaxValue = 100;

            public const int RepsMinValue = 1;
            public const int RepsMaxValue = 1000;

            public const double WeightMinValue = 0.0;
            public const double WeightMaxValue = 1000.0;

            public const double DistanceMinValue = 0.0;
            public const double DistanceMaxValue = 10000.0;

            public static readonly TimeSpan DurationMinValue = TimeSpan.Zero;
            public static readonly TimeSpan DurationMaxValue = TimeSpan.FromHours(24);
        }

        public static class WorkoutLog
        {
            public const int SessionNameMaxLength = 300;
            public const string SessionDefaultName = "Workout";
        }

        public static class WorkoutItem
        {
            public const int TemplateItemDefaultSets = 3;
        }

        public static class WorkoutTemplate
        {
            public const int NameMaxLength = 200;
            public const int DescriptionMaxLength = 1000;
        }
    }
}
