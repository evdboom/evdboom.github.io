using OptionA.Blog.Components.Code.Parsers;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Line;

namespace OptionA.Blog.Components.Code
{
    public class CodeBuilder<Parent> : MainContentBuilderBase<CodeBuilder<Parent>, Parent, CodeContent>
        where Parent : IParentBuilder
    {
        private readonly Dictionary<CodeLanguage, IParser> _parsers;

        public CodeBuilder(Parent parent) : base(parent)
        {
            _parsers = new Dictionary<CodeLanguage, IParser>()
            {
                { CodeLanguage.CSharp, new CSharpParser() }
            };

            _style = Style.Inherit;
            _textAlignment = PositionType.Left;
            _blockType = BlockType.Content;
            _blockAlignment = PositionType.Left;
        }

        public CodeBuilder<Parent> ForLanguage(CodeLanguage language)
        {
            _content.Language = language;

            if (_parsers.TryGetValue(_content.Language, out IParser? parser))
            {
                _content.Parser = parser;
            }

            return this;
        }

        public CodeBuilder<Parent> WithCode(string code)
        {
            _content.Code = code;
            return this;
        }

        protected override CodeBuilder<Parent> This()
        {
            return this;
        }

        protected override void OnBuild()
        {
            base.OnBuild();
        }        
    }
}
