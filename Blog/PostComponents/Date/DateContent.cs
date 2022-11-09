using Blog.PostComponents.Line;

namespace Blog.PostComponents.Date
{
    public class DateContent : LineContent
    {
        public DateTimeOffset Date { get; set; }
        public DateDisplayType DisplayType { get; set; }        
        public override ComponentType Type => ComponentType.Date;
        public override string Text
        {
            get => DisplayType switch
            {
                DateDisplayType.Date => $"{Date:d}",
                DateDisplayType.DateTime => $"{Date:g}",
                DateDisplayType.Time => $"{Date:t}",
                DateDisplayType.UsableDate => $"{Date:yyyyMMdd}",
                DateDisplayType.UsableDateTime => $"{Date:u}",
                DateDisplayType.LongDate => $"{Date:D}",
                DateDisplayType.LongDateTime => $"{Date:f}",
                DateDisplayType.Month => $"{Date:MMMM}",
                DateDisplayType.Year => $"{Date:yyyy}",
                DateDisplayType.YearMonth => $"{Date:Y}",
                _ => throw new ArgumentException($"Unknown DisplayType {DisplayType}")
            };
            set => throw new InvalidOperationException("Cannot set Text of Date component, set Date property instead");
        }
    }
}
