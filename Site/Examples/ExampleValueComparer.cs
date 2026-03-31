namespace OptionA.Site.Examples
{
    public class ExampleValueComparer : IComparer<ExampleObject>
    {
        public int Compare(ExampleObject? x, ExampleObject? y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.Value.CompareTo(y.Value);
        }
    }
}
