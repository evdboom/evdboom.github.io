using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.List
{
    public class ListContent : PostContent
    {
        public override ComponentType Type => ComponentType.List;

        public ListStyle ListStyle { get; set; }
        public bool Ordered { get; set; }
        public int Start { get; set; } = 1;

        protected override IEnumerable<string> GetContentClassesList()
        {
            if (DefaultClasses.ListStyleClasses.TryGetValue(ListStyle, out string? className))
            {
                yield return className;
            }
        }
    }
}
