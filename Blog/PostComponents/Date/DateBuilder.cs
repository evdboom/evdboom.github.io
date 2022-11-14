using Blog.Builders;
using Blog.Enums;

namespace Blog.PostComponents.Date
{
    public class DateBuilder<Parent> : SubBuilderBase<DateBuilder<Parent>, Parent, DateContent>
        where Parent : IParentBuilder
    {
        public DateBuilder(Parent parent) : base(parent)
        {
        }

        public Parent AddDate(DateTime date, DateDisplayType display, Style style)
        {
            _content.Date = date;
            _content.DisplayType = display;
            _content.Style = style;
            return Build();
        }

        protected override DateBuilder<Parent> This()
        {
            return this;
        }
    }
}
