using Blog.Enums;
using Blog.PostComponents;

namespace Blog.Builders
{
    public class PostBuilder : BuilderBase<PostBuilder, PostItem>
    {
        private PostItemContent? _currentItem;

        protected PostBuilder() : base(new PostItem(), BlockType.Normal, PositionType.Inherit, Style.Normal)
        {
        }

        public static PostBuilder CreatePost()
        {
            return new PostBuilder();
        }       

        public PostBuilder WithTitle(string title)
        {
            if (!string.IsNullOrEmpty(_result.Title))
            {
                throw new InvalidOperationException("Can only set title once");
            }

            _result.Title = title;

            return this;
        }

        public PostBuilder WithSubTitle(string subTitle)
        {
            if (!string.IsNullOrEmpty(_result.SubTitle))
            {
                throw new InvalidOperationException("Can only set subTitle once");
            }

            _result.SubTitle = subTitle;

            return this;
        }

        public PostBuilder WithDate(int year, int month, int day)
        {
            return WithDate(new DateTime(year, month, day));
        }

        public PostBuilder WithDate(DateTime postDate)
        {
            if (_result.PostDate != DateTime.MinValue)
            {
                throw new InvalidOperationException("Can only set post date once");
            }

            _result.PostDate = postDate;

            return this;
        }
       
        public PostBuilder StartContent(PostItemContent content)
        {
            if (!content.SupportsCustomChildContent)
            {
                throw new InvalidOperationException("This content type does not support custom child content");
            }

            AddContent(content);
            _currentItem = content;

            return this;            
        }

        public PostBuilder AddContent(PostItemContent content)
        {
            if (_currentItem is null)
            {
                _result.Content.Add(content);
                
            }
            else
            {
                _currentItem.ChildContent.Add(content);
                content.Parent = _currentItem;
            }
            SetContentProperties(content);
            
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

        public TableBuilder CreateTable()
        {
            return TableBuilder.CreateTable(this, _blockType, _textAlignment, _style);
        }

        protected override PostBuilder This()
        {
            return this;
        }
    }
}
