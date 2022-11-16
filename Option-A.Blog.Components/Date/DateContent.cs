using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Line;

namespace OptionA.Blog.Components.Date
{
    public class DateContent : LineContent
    {
        public DateTime Date { get; set; }
        public DateDisplayType DisplayType { get; set; }        
        public override ComponentType Type => ComponentType.Date;
        public override string Text
        {
            get => DisplayType.ToDateFormat(Date); 
            set => throw new InvalidOperationException("Cannot set Text of Date component, set Date property instead");
        }
    }
}
