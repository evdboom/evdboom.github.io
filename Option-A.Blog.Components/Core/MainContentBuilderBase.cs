namespace OptionA.Blog.Components.Core
{
    public abstract class MainContentBuilderBase<Builder, Parent, Content> : ContentBuilderBase<Builder, Parent, Content>
        where Parent : IParentBuilder
        where Content : IPostContent, new()
    {

        protected MainContentBuilderBase(Parent parent) : base(parent, parent.Style, parent.TextAlignment, parent.BlockType, parent.BlockAlignment, parent.Color)
        {

        }

        protected override void OnBuild()
        {
            _result.AddContent(_content);
            base.OnBuild();
        }
    }
}
