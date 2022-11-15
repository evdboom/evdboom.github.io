using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Date
{
    public class DateBuilder<Parent> : MainContentBuilderBase<DateBuilder<Parent>, Parent, DateContent>
        where Parent : IParentBuilder
    {
        public DateBuilder(Parent parent) : base(parent)
        {
        }

        public DateBuilder<Parent> ForDate(DateTime date)
        {
            _content.Date = date; 
            return this;
        }

        public DateBuilder<Parent> WithDisplayType(DateDisplayType display)
        {
            _content.DisplayType = display;
            return this;
        }

        protected override DateBuilder<Parent> This()
        {
            return this;
        }
    }
}
