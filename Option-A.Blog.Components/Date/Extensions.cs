using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Date
{
    public static class Extensions
    {
        public static DateBuilder<Parent> CreateDate<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new DateBuilder<Parent>(parent);
        }

        public static Parent AddDate<Parent>(this Parent parent, DateTime date) where Parent : IParentBuilder
        {
            return AddDate(parent, date, DateDisplayType.Date);
        }

        public static Parent AddDate<Parent>(this Parent parent, DateTime date, DateDisplayType display) where Parent : IParentBuilder
        {
            return CreateDate(parent)
                .ForDate(date)
                .WithDisplayType(display)
                .Build();
        }

        public static string ToDateFormat(this DateDisplayType type, DateTime date)
        {
            return type switch
            {
                DateDisplayType.Date => $"{date:d}",
                DateDisplayType.DateTime => $"{date:g}",
                DateDisplayType.Time => $"{date:t}",
                DateDisplayType.UsableDate => $"{date:yyyyMMdd}",
                DateDisplayType.UsableDateTime => $"{date:u}",
                DateDisplayType.LongDate => $"{date:D}",
                DateDisplayType.LongDateTime => $"{date:f}",
                DateDisplayType.Month => $"{date:MMMM}",
                DateDisplayType.Year => $"{date:yyyy}",
                DateDisplayType.YearMonth => $"{date:Y}",
                _ => throw new ArgumentException($"Unknown DisplayType {type}")
            };
        }
    }
}
