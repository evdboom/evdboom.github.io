using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    public abstract class BuilderBase<Builder, Result> : IBuilder
    {
        protected readonly Result _result;

        protected Style _style;
        /// <summary>
        /// Gets the currently set <see cref="Enums.Style" /> for this builder, Style is copied to child builders.
        /// </summary>
        public Style Style => _style;

        protected PositionType _textAlignment;
        /// <summary>
        /// Gets the currently set <see cref="Enums.PositionType" /> for the text alignment for this builder, TextAlignment is copied to child builders.
        /// </summary>
        public PositionType TextAlignment => _textAlignment;

        protected BlockType _blockType;
        /// <summary>
        /// Gets the currently set <see cref="Enums.BlockType" /> for this builder, BlockType is copied to child builders.
        /// </summary>
        public BlockType BlockType => _blockType;

        protected PositionType _blockAlignment;
        /// <summary>
        /// Gets the currently set <see cref="Enums.PositionType" /> for the block alignment for this builder, BlockAlignment is copied to child builders.
        /// </summary>
        public PositionType BlockAlignment => _blockAlignment;

        protected BlogColor _color;
        /// <summary>
        /// Gets the currently set <see cref="Enums.BlogColor" /> for this builder, Color is only copied to child builders that do not have a default color themselves. 
        /// </summary>
        public BlogColor Color => _color;
        protected virtual BlogColor _ownColor => BlogColor.Inherit;


        protected BuilderBase(Result result, Style style, PositionType textAlignment, BlockType blockType, PositionType blockAlignment, BlogColor color)
        {
            _style = style;
            _textAlignment = textAlignment;
            _blockAlignment = blockAlignment;
            _blockType = blockType;
            _result = result;
            _color = _ownColor != BlogColor.Inherit
                ? _ownColor
                : color;
        }

        /// <summary>
        /// Builds the current builder, calls the <see cref="OnBuild"/> method and then returning the <see cref="Result"/>
        /// </summary>
        /// <returns></returns>
        public Result Build()
        {
            OnBuild();
            return _result;
        }

        /// <summary>
        /// Sets the <see cref="TextAlignment"/> for the current builder. Child builders created after this will also inherit this text alignment
        /// </summary>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public Builder WithTextAlignment(PositionType alignment)
        {
            _textAlignment = alignment;
            return This();
        }

        /// <summary>
        /// Seth the <see cref="Color" /> for the current builder. Child builders created after this will inherit this color if they do not have a default color themselves
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Builder WithColor(BlogColor color)
        {
            _color = color;
            return This();
        }

        /// <summary>
        /// Sets the <see cref="BlockAlignment"/> for the current builder. Child builders created after this will also inherit this block alignment
        /// </summary>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public Builder WithBlockAlignment(PositionType alignment)
        {
            _blockAlignment = alignment;
            return This();
        }

        /// <summary>
        /// Sets the <see cref="Style"/> for the current builder, overrides all previously set styles. Child builders created after this will also inherit this Style
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public Builder WithStyle(Style style)
        {
            _style = style;
            return This();
        }

        /// <summary>
        /// Adds the given style to the <see cref="Style"/> for the current builder, keeps previously set styles. Child builders created after this will also inherit this Style
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public Builder AddStyle(Style style)
        {
            _style |= style;
            return This();
        }

        /// <summary>
        /// Removes the given style from the the <see cref="Style"/> for the current builder, keeps other set styles. Child builders created after this will also not have this style
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public Builder RemoveStyle(Style style)
        {
            _style &= ~style;
            return This();
        }

        /// <summary>
        /// Sets the <see cref="BlockType"/> for the currenty builder, Child builders created after this will also have this BlockStyle
        /// </summary>
        /// <param name="blockType"></param>
        /// <returns></returns>
        public Builder WithBlockType(BlockType blockType)
        {
            _blockType = blockType;
            return This();
        }

        /// <summary>
        /// Should be set to 'return this;' to make the return call for generic set methods return the correct builder to make it easier chainable.
        /// </summary>
        /// <returns></returns>
        protected abstract Builder This();

        /// <summary>
        /// Called during builder build, override to add custom build logic
        /// </summary>
        protected virtual void OnBuild()
        {
        }
    }
}
