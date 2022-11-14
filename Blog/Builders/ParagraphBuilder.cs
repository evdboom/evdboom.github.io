using Blog.Enums;
using Blog.PostComponents;
using Blog.PostComponents.Paragraph;

namespace Blog.Builders
{
    public class ParagraphBuilder<Parent> : SubBuilderBase<ParagraphBuilder<Parent>, Parent, ParagraphContent>, IParentBuilder
        where Parent : IParentBuilder
    {

        public ParagraphBuilder(Parent parent) : base(parent) 
        {

        }

        public void AddContent(PostItemContent content)
        {
            SetContentProperties(content);
            _content.ChildContent.Add(content);
        }

        protected override ParagraphBuilder<Parent> This()
        {
            return this;
        }
    }
}
