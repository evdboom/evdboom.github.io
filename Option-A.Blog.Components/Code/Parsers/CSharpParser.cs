namespace OptionA.Blog.Components.Code.Parsers
{
    /// <summary>
    /// Parser for parsing c# code to a more readable format.
    /// </summary>
    public class CSharpParser : IParser
    {
        private readonly List<string> _controlKeyWords = new()
        {
            "break",
            "case",
            "continue",
            "do",
            "else",
            "for",
            "foreach",
            "if",
            "return",
            "switch",
            "throw",
            "using",
            "try",
            "catch",
            "finally",
            "yield",
            "while",
        };
        private readonly List<string> _keyWords = new()
        {
            "abstract",
            "as",
            "base",
            "bool",
            "byte",
            "char",
            "checked",
            "class",
            "const",
            "decimal",
            "default",
            "delegate",
            "double",
            "enum",
            "event",
            "explicit",
            "extern",
            "false",
            "fixed",
            "float",
            "goto",
            "implicit",
            "in",
            "int",
            "interface",
            "internal",
            "is",
            "lock",
            "long",
            "namespace",
            "new",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "sbyte",
            "sealed",
            "short",
            "sizeof",
            "stackalloc",
            "static",
            "string",
            "struct",
            "this",
            "true",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "virtual",
            "void",
            "volatile",
            "add",
            "and",
            "alias",
            "ascending",
            "args",
            "async",
            "await",
            "by",
            "descending",
            "dynamic",
            "equals",
            "file",
            "from",
            "get",
            "global",
            "group",
            "init",
            "into",
            "join",
            "let",
            "managed",
            "nameof",
            "nint",
            "not",
            "notnull",
            "nuint",
            "on",
            "or",
            "orderby",
            "partial",
            "record",
            "remove",
            "required",
            "scoped",
            "select",
            "set",
            "unmanaged",
            "value",
            "var",
            "when",
            "where",
            "with",
        };
        private readonly char[] _specials = new[]
        {
            ' ',
            '(',
            '<',
            '.',
            '\'',
            ')',
            '>',
            '{',
            '}',
            '=',
            '!',
            ';',
            ',',
            '|',
        };

        private readonly string _selectionMarker = "*M*";

        private readonly Dictionary<string, WordType> _starters = new()
        {
            { "\"", WordType.String },
            { "@\"", WordType.String },
            { "$\"", WordType.Interpolated },
            { "$@\"", WordType.Interpolated },
            { "@$\"", WordType.Interpolated },
            { "*", WordType.Marker },
            { "//", WordType.Comment }
        };

        /// <inheritdoc/>
        public IEnumerable<(string Part, CodePart Type, bool Selected)> GetParts(string code)
        {
            var current = string.Empty;
            var selected = false;
            var incomplete = WordType.Unknown;
            var endedInside = false;
            while (!string.IsNullOrEmpty(code))
            {
                var word = FindNextWord(code, incomplete, out WordType wordType);
                code = RemoveFromStart(code, word);

                if (word == _selectionMarker)
                {
                    if (!string.IsNullOrEmpty(current))
                    {
                        yield return (current, CodePart.Text, selected);
                        current = string.Empty;
                    }
                    selected = !selected;
                    continue;
                }

                var isIncomplete = wordType.HasFlag(WordType.Incomplete);
                wordType &= ~WordType.Incomplete;

                incomplete = isIncomplete
                    ? wordType
                    : WordType.Unknown;

                switch (wordType)
                {
                    case WordType.String:
                        if (!string.IsNullOrEmpty(current))
                        {
                            yield return (current, CodePart.Text, selected);
                            current = string.Empty;
                        }
                        yield return (word, CodePart.String, selected);
                        break;
                    case WordType.Interpolated:
                        if (!string.IsNullOrEmpty(current))
                        {
                            yield return (current, CodePart.Text, selected);
                            current = string.Empty;
                        }                        
                        foreach (var (part, type, inside) in ParseInterpolatedString(word, endedInside))
                        {
                            endedInside = inside;
                            yield return (part, type, selected);
                        }
                        break;
                    case WordType.Comment:
                        if (!string.IsNullOrEmpty(current))
                        {
                            yield return (current, CodePart.Text, selected);
                            current = string.Empty;
                        }
                        yield return (word, CodePart.Comment, selected);
                        break;
                    case WordType.Unknown:
                        if (_keyWords.Contains(word))
                        {
                            if (!string.IsNullOrEmpty(current))
                            {
                                yield return (current, CodePart.Text, selected);
                                current = string.Empty;
                            }
                            yield return (word, CodePart.Keyword, selected);
                        }
                        else if (_controlKeyWords.Contains(word))
                        {
                            if (!string.IsNullOrEmpty(current))
                            {
                                yield return (current, CodePart.Text, selected);
                                current = string.Empty;
                            }
                            yield return (word, CodePart.ControlKeyword, selected);
                        }
                        else if (IsMethodStart(current, code.FirstOrDefault()))
                        {
                            if (!string.IsNullOrEmpty(current))
                            {
                                yield return (current, CodePart.Text, selected);
                                current = string.Empty;
                            }
                            yield return (word, CodePart.Method, selected);
                        }
                        else
                        {
                            current += word;
                        }
                        break;
                }
            }
            if (!string.IsNullOrEmpty(current))
            {
                yield return (current, CodePart.Text, selected);
            }
        }

        private static bool IsMethodStart(string current, char nextChar)
        {
            return nextChar == '(' &&
                (string.IsNullOrEmpty(current)
                || current.EndsWith(' ')
                || current.EndsWith('.'));
        }

        private IEnumerable<(string Part, CodePart Type, bool Inside)> ParseInterpolatedString(string word, bool beginInside)
        {
            var interpolated = word.Split('{', '}');
            var inside = beginInside;
            for (int i = 0; i < interpolated.Length; i++)
            {
                var part = interpolated[i];
                var last = i == interpolated.Length - 1;

                if (inside)
                {
                    var start = beginInside
                        ? string.Empty
                        : "{";
                    var end = last
                        ? string.Empty
                        : "}";

                    var insidePart = $"{start}{part}{end}";
                    beginInside = false;

                    foreach (var p in GetParts(insidePart))
                    {
                        yield return (p.Part, p.Type, last);
                    }
                }
                else
                {
                    yield return (part, CodePart.String, false);
                }
                inside = !inside;
            }
        }

        private static string RemoveFromStart(string text, string toRemove)
        {
            if (!text.StartsWith(toRemove))
            {
                throw new ArgumentException($"{toRemove} is not the start of {text})");
            }

            return text.Substring(toRemove.Length);

        }

        private string FindNextWord(string code, WordType incomplete, out WordType wordType)
        {

            if (string.IsNullOrEmpty(code))
            {
                wordType = WordType.Unknown;
                return string.Empty;
            }

            var word = string.Empty;
            var starter = _starters.FirstOrDefault(s => code.StartsWith(s.Key));
            wordType = starter.Value;

            if (wordType == WordType.Marker)
            {
                if (code.StartsWith(_selectionMarker))
                {
                    return _selectionMarker;
                }
            }
            else if (incomplete != WordType.Unknown)
            {
                wordType = incomplete;
            }


            if (wordType == WordType.Comment)
            {
                word = FindTillValue(code, 0, Environment.NewLine);
            }
            else if (wordType != WordType.Unknown)
            {
                word = FindTillValue(code, starter.Key?.Length ?? 0, "\"");
            }
            else
            {
                var firstChar = code[0];
                var special = _specials.Contains(firstChar);
                word += firstChar;

                var found = false;
                var counter = 1;
                while (!found && counter < code.Length)
                {
                    var c = code[counter];
                    var isSpecial = _specials.Contains(c);
                    if ((special && !isSpecial) || (!special && isSpecial))
                    {
                        found = true;
                    }
                    else
                    {
                        word += c;
                    }
                    counter++;
                }
            }

            if (word.Contains(_selectionMarker))
            {
                wordType |= WordType.Incomplete;
            }

            return word
                .Split(_selectionMarker)
                .FirstOrDefault() ?? string.Empty;
        }

        private static string FindTillValue(string text, int start, string searchValue)
        {
            var next = text.IndexOf(searchValue, start);
            if (next < 0)
            {
                return text;
            }
            var untill = next + searchValue.Length;
            var result = text[..untill];
            return result;
        }
    }
}
