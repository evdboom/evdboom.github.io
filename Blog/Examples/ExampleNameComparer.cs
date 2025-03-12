namespace Blog.Examples
{
    public class ExampleNameComparer : IComparer<ExampleObject>
    {
        public int Compare(ExampleObject? x, ExampleObject? y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
