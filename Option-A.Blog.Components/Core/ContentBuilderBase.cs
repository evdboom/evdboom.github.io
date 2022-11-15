using OptionA.Blog.Components.Code;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    public abstract class ContentBuilderBase<Builder, Parent, Content> : BuilderBase<Builder, Parent>
        where Content : IPostContent, new()
    {
        protected readonly Content _content;
        

        protected ContentBuilderBase(Parent parent, Style style, PositionType textAlignment, BlockType blockType, PositionType blockAlignment, BlogColor color) : base(parent, style, textAlignment, blockType, blockAlignment, color)
        {
            _content = new();
            if (DefaultClasses.ContentClasses.TryGetValue(typeof(Content), out var classes))
            {
                foreach (var className in classes)
                {
                    AddClass(className);
                }
            }
        }

        public Builder AddClass(string className)
        {            
            if (!string.IsNullOrEmpty(className) && !_content.AdditionalClasses.Contains(className))
            {
                _content.AdditionalClasses.Add(className);
            }
            return This();
        }

        public Builder RemoveClass(string className)
        {
            if (!string.IsNullOrEmpty(className) && _content.AdditionalClasses.Contains(className))
            {
                _content.AdditionalClasses.Remove(className);
            }
            return This();
        }

        protected override void OnBuild()
        {
            _content.SetProperties(this);
            base.OnBuild();
        }
    }
}
