using OptionA.Blog.Components.Code.Parsers;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Line;
using OptionA.Blog.Components.Paragraph;

namespace OptionA.Blog.Components.Code
{
    public class CodeContent : ParagraphContent
    {
        public IParser? Parser { get; set; }
        public string Code { get; set; } = string.Empty;
        public CodeLanguage Language { get; set; }
        public override ComponentType Type => ComponentType.Code;

        public override IList<IPostContent> ChildContent => GetChildren()
            .ToList();

        protected override IEnumerable<string> GetContentClassesList()
        {
            if (!string.IsNullOrEmpty(DefaultClasses.CodeBlock))
            {
                yield return DefaultClasses.CodeBlock;
            }
        }

        private IEnumerable<IPostContent> GetChildren()
        {
            if (Language != CodeLanguage.Other)
            {
                var header = new LineContent
                {
                    Text = Language.ToDisplayLanguage(),
                    TextAlignment = PositionType.Right,
                    BlockType = BlockType.Normal,
                    Style = Style.Bold
                };

                if (!string.IsNullOrEmpty(DefaultClasses.CodeHeaderBlock))
                {
                    header.AdditionalClasses.Add(DefaultClasses.CodeHeaderBlock);
                }

                yield return header;
            }

            if (Parser is null)
            {
                yield return new LineContent
                {
                    Text = Code,
                    BlockType = BlockType.Content
                };
                yield break;
            }

            foreach (var (part, type) in Parser.GetParts(Code))
            {
                var content = new LineContent
                {
                    Text = part,
                    BlockType = type == CodePart.Text
                        ? BlockType.Content
                        : BlockType.Inline
                };
                if (type != CodePart.Text)
                {
                    var className = type.GetPartClass();
                    if (!string.IsNullOrEmpty(className))
                    {
                        content.AdditionalClasses.Add(className);
                    }
                }
                yield return content;
            }
        }
    }
}
