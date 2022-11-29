using static System.Net.Mime.MediaTypeNames;

namespace OptionA.Blog.Components.Code.Parsers
{
    /// <summary>
    /// Parser for parsing html (and razor syntax) in a readable format
    /// </summary>
    public class HtmlParser : IParser
    {
        private readonly List<string> _htmlElements = new()
        {
            "html",
            "base",
            "head",
            "link",
            "meta",
            "style",
            "title",
            "body",
            "address",
            "article",
            "aside",
            "footer",
            "header",
            "h1",
            "h2",
            "h3",
            "h4",
            "h5",
            "h6",
            "main",
            "nav",
            "section",
            "blockquote",
            "dd",
            "div",
            "dl",
            "dt",
            "figcaption",
            "figure",
            "hr",
            "li",
            "menu",
            "ol",
            "p",
            "pre",
            "ul",
            "a",
            "abbr",
            "b",
            "bdi",
            "bdo",
            "br",
            "cite",
            "code",
            "data",
            "dfn",
            "em",
            "i",
            "kbd",
            "mark",
            "q",
            "rp",
            "rt",
            "ruby",
            "s",
            "samp",
            "small",
            "span",
            "strong",
            "sub",
            "sup",
            "time",
            "u",
            "var",
            "wbr",
            "area",
            "audio",
            "img",
            "map",
            "track",
            "video",
            "embed",
            "iframe",
            "object",
            "picture",
            "portal",
            "source",
            "svg",
            "math",
            "canvas",
            "noscript",
            "script",
            "del",
            "ins",
            "caption",
            "col",
            "colgroup",
            "table",
            "tbody",
            "td",
            "tfoot",
            "th",
            "thead",
            "tr",
            "button",
            "datalist",
            "fieldset",
            "form",
            "input",
            "label",
            "legend",
            "meter",
            "optgroup",
            "option",
            "output",
            "progress",
            "select",
            "textarea",
            "details",
            "dialog",
            "summary",
            "slot",
            "template"
        };

        private readonly CSharpParser _razor = new();
        private readonly Dictionary<string, string> _csharpStarters = new()
        {
            { "(", ")" },
            { "using", Environment.NewLine },
            { "if", "}" },
            { "switch", "}" },
            { "foreach", "}" }
        };

        private readonly char _tagStarter = '<';
        private readonly char _cSharpStart = '@';

        /// <inheritdoc/>
        public IEnumerable<(string Part, CodePart Type, bool Selected)> GetParts(string code)
        {
            var current = string.Empty;
            var selected = false;
            while (string.IsNullOrEmpty(code))
            {
                var word = FindNextWord(code, out WordType wordType);
                code = RemoveFromStart(code, word);
            }

            throw new NotImplementedException();
        }

        private string FindNextWord(string code, out WordType wordType)
        {
            if (string.IsNullOrEmpty(code))
            {
                wordType = WordType.Unknown;
                return string.Empty;
            }

            var word = string.Empty;
            throw new NotImplementedException();
        }

        private static string RemoveFromStart(string text, string toRemove)
        {
            if (!text.StartsWith(toRemove))
            {
                throw new ArgumentException($"{toRemove} is not the start of {text})");
            }

            return text.Substring(toRemove.Length);

        }
    }
}
