namespace Blog.PostComponents.Header
{
    public class HeaderContent : PostItemContent
    {
        public HeaderSize HeaderSize { get; set; }
        public override ComponentType Type => ComponentType.Header;
        public override bool SupportsCustomChildContent => false;
        protected override List<string> GetClassesList()
        {
            var initial = base.GetClassesList();
            initial.Add(HeaderSize.GetSizeClass());
            return initial;
        }
    }
}
