namespace OptionA.Site.Examples
{
    public class ExampleColorComparer : IComparer<ExampleObject>
    {
        public int Compare(ExampleObject? x, ExampleObject? y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return string.Compare(x.Color, y.Color, StringComparison.OrdinalIgnoreCase);
        }
    }
}
