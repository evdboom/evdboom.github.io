using Blog.Enums;
using Blog.PostComponents;

namespace Blog.Builders
{
    public class PostBuilder
    {
        private readonly PostItem _post;
        private PostItemContent? _currentItem;
        private BlockType _blockType;
        private PositionType _textAlignment;
        private Style _style;

        private PostBuilder()
        {
            _blockType = BlockType.Normal;
            _style = Style.Normal;
            _textAlignment = PositionType.Inherit;
            _post = new();
        }

        public static PostBuilder CreatePost()
        {
            return new PostBuilder();
        }

        public PostBuilder SetStyle(Style style)
        {
            _style = style;
            return this;
        }

        public PostBuilder RemoveStyle(Style style)
        {
            _style &= ~style;
            return this;
        }

        public PostBuilder AddToStyle(Style style)
        {
            if (_style == Style.Normal)
            {
                _style = style;
            }
            else if (!_style.HasFlag(style))
            {
                _style |= style;
            }

            return this;
        }

        public PostBuilder ResetStyle()
        {
            return SetStyle(Style.Normal);
        }

        public PostBuilder WithTitle(string title)
        {
            if (!string.IsNullOrEmpty(_post.Title))
            {
                throw new InvalidOperationException("Can only set title once");
            }

            _post.Title = title;

            return this;
        }

        public PostBuilder WithSubTitle(string subTitle)
        {
            if (!string.IsNullOrEmpty(_post.SubTitle))
            {
                throw new InvalidOperationException("Can only set subTitle once");
            }

            _post.SubTitle = subTitle;

            return this;
        }

        public PostBuilder WithDate(int year, int month, int day)
        {
            return WithDate(new DateTime(year, month, day));
        }

        public PostBuilder WithDate(DateTime postDate)
        {
            if (_post.PostDate != DateTime.MinValue)
            {
                throw new InvalidOperationException("Can only set post date once");
            }

            _post.PostDate = postDate;

            return this;
        }

        public PostBuilder SetBlockType(BlockType type)
        {
            if (_blockType == type)
            {
                throw new InvalidOperationException($"Blocktype {type} already enabled!");
            }

            _blockType = type;
            return this;
        }

        public PostBuilder ResetBlockType()
        {
            _blockType = BlockType.Normal;
            return this;
        }

        public PostBuilder SetJustContent()
        {
            return SetBlockType(BlockType.Content);
        }

        public PostBuilder SetInline()
        {
            return SetBlockType(BlockType.Inline);
        }

        public PostBuilder SetBlocks()
        {
            return ResetBlockType();
        }

        public PostBuilder AlignText(PositionType type)
        {
            _textAlignment = type;
            return this;
        }

        public PostBuilder AlignTextLeft()
        {
            return AlignText(PositionType.Left);
        }

        public PostBuilder AlignTextCenter()
        {
            return AlignText(PositionType.Center);
        }

        public PostBuilder AlignTextRight()
        {
            return AlignText(PositionType.Right);
        }

        public PostBuilder ResetTextAlignment()
        {
            return AlignText(PositionType.Inherit);
        }

        public PostBuilder StartContent(PostItemContent content)
        {
            AddContent(content);
            _currentItem = content;

            return this;            
        }

        public PostBuilder AddContent(PostItemContent content)
        {
            if (_currentItem is null)
            {
                _post.Content.Add(content);
                
            }
            else
            {
                _currentItem.ChildContent.Add(content);
                content.Parent = _currentItem;
            }
            if (content.BlockType == BlockType.Normal)
            {
                content.BlockType = _blockType;
            }
            
            if (content.TextPosition == PositionType.Inherit)
            {
                content.TextPosition = _textAlignment;
            }
            
            if (content.Style == Style.Normal)
            {
                content.Style = _style;
            }
            
            return this;
        }

        public PostBuilder EndContent(ComponentType expectedType)
        {
            if (_currentItem is null)
            {
                throw new InvalidOperationException("Content does not have parent, are you at the top level?");
            }
            else if (expectedType != _currentItem.Type)
            {
                throw new InvalidOperationException($"Open Content is of type ${_currentItem.Type}, are you at the correct level?");
            }

            _currentItem = _currentItem.Parent;

            return this;
        }

        public PostItem Build()
        {
            return _post;
        }
    }
}
