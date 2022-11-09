using Blog.Enums;
using Blog.PostComponents;

namespace Blog.Builders
{
    public abstract class BuilderBase<Builder, Result>
        where Builder : BuilderBase<Builder, Result>
    {
        protected readonly Result _result;

        protected BlockType _blockType;
        protected PositionType _textAlignment;
        protected Style _style;

        protected BuilderBase(Result result, BlockType block, PositionType textAlignment, Style style)
        {
            _result = result;
            _blockType = block;
            _textAlignment = textAlignment;
            _style = style;
        }

        public Builder SetStyle(Style style)
        {
            _style = style;
            return This();
        }

        public Builder RemoveStyle(Style style)
        {
            _style &= ~style;
            return This();
        }

        public Builder AddToStyle(Style style)
        {
            if (_style == Style.Normal)
            {
                _style = style;
            }
            else if (!_style.HasFlag(style))
            {
                _style |= style;
            }

            return This();
        }

        public Builder ResetStyle()
        {
            return SetStyle(Style.Normal);
        }

        public Builder SetBlockType(BlockType type)
        {
            if (_blockType == type)
            {
                throw new InvalidOperationException($"Blocktype {type} already enabled!");
            }

            _blockType = type;
            return This();
        }

        public Builder ResetBlockType()
        {
            _blockType = BlockType.Normal;
            return This();
        }

        public Builder SetJustContent()
        {
            return SetBlockType(BlockType.Content);
        }

        public Builder SetInline()
        {
            return SetBlockType(BlockType.Inline);
        }

        public Builder SetBlocks()
        {
            return ResetBlockType();
        }

        public Builder AlignText(PositionType type)
        {
            _textAlignment = type;
            return This();
        }

        public Builder AlignTextLeft()
        {
            return AlignText(PositionType.Left);
        }

        public Builder AlignTextCenter()
        {
            return AlignText(PositionType.Center);
        }

        public Builder AlignTextRight()
        {
            return AlignText(PositionType.Right);
        }

        public Builder ResetTextAlignment()
        {
            return AlignText(PositionType.Inherit);
        }

        public Result Build()
        {
            OnBuild();
            return _result;
        }

        protected virtual void SetContentProperties(PostItemContent content)
        {
            if (content.BlockType == BlockType.Normal)
            {
                content.BlockType = _blockType;
            }

            if (content.TextPosition == PositionType.Inherit)
            {
                content.TextPosition = _textAlignment;
            }

            if (content.Style == Style.Normal || content.Style == Style.Inherit)
            {
                content.Style = _style;
            }
        }

        protected abstract Builder This();
        protected virtual void OnBuild()
        {

        }
    }
}
