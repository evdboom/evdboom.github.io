using Blog.Builders;
using Blog.Enums;
using Blog.Extensions;

namespace Blog.PostComponents.Date
{
    public static class AddExtensions
    {        
        public static DateBuilder<Parent> CreateDate<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new DateBuilder<Parent>(parent);
        }

        public static Parent AddDate<Parent>(this Parent parent, DateTime date) where Parent : IParentBuilder
        {
            return AddDate(parent, date, Style.Inherit);
        }

        public static Parent AddDate<Parent>(this Parent parent, DateTime date, Style style) where Parent : IParentBuilder
        {
            return AddDate(parent, date, DateDisplayType.Date, style);
        }

        public static Parent AddDate<Parent>(this Parent parent, DateTime date, DateDisplayType display) where Parent : IParentBuilder
        {
            return AddDate(parent, date, display, Style.Inherit);
        }

        public static Parent AddDate<Parent>(this Parent parent, DateTime date, DateDisplayType display, Style style) where Parent : IParentBuilder
        {
            return CreateDate(parent)
                .AddDate(date, display, style);            
        }
    }
}
