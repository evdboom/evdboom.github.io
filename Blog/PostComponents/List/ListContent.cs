using Blog.Enums;

namespace Blog.PostComponents.List
{
    public class ListContent : PostItemContent
    {
        public override ComponentType Type => ComponentType.List;
        public override bool SupportsCustomChildContent => false;

        public ListStyle ListStyle { get; set; }
        public Orientation Orientation { get; set; }
        public bool Ordered { get; set; }
        public bool BoldNumbering { get; set; }
        public int Start { get; set; }

        private readonly List<string> _itemClasses = new()
        {
            "list-group-item"
        };
        public string GetItemClasses()
        {
            return string.Join(' ', _itemClasses);
        }

        public string GetStyle()
        {
            if (Ordered && Start > 0)
            {
                return $"counter-set: section {Start}";
            }

            return string.Empty;
        }

        public override void Build(PostItem post)
        {
            AdditionalClasses.Add("list-group mb-2");
            if (Ordered)
            {
                AdditionalClasses.Add("list-group-numbered");
            }
            if (Orientation == Orientation.Horizontal)
            {
                AdditionalClasses.Add("list-group-horizontal");
                _itemClasses.Add("flex-fill");
            }
            if (BoldNumbering)
            {
                AdditionalClasses.Add("bold-numbers");
            }
            AdditionalClasses.Add(ListStyle.GetTypeClass());
            base.Build(post);
        }

    }
}
