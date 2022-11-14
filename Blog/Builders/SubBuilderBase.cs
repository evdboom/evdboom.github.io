using Blog.Enums;
using Blog.PostComponents;

namespace Blog.Builders
{
    public abstract class SubBuilderBase<Builder, Parent, Content> : BuilderBase<Builder, Parent>
        where Builder : SubBuilderBase<Builder, Parent, Content>
        where Parent : IParentBuilder
        where Content : PostItemContent, new()
    {
        protected readonly Content _content;

        protected SubBuilderBase(Parent parent) : base(parent, parent.BlockType, parent.TextAlignment, parent.Style)
        {
            _content = new();
            SetContentProperties(_content);
        }

        protected override void OnBuild()
        {
            _result.AddContent(_content);
        }
    }
}
