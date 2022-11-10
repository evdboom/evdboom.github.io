namespace Blog.PostComponents.Code
{
    public static class CodePartUtil
    {
        private static readonly List<string> _controlKeyWords = new()
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
        private static readonly List<string> _keyWords = new()
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
        private static readonly char[] _specials = new[]
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
            '|'
        };

        private static readonly Dictionary<string, StringType> StringStarters = new()
        {
            { "\"", StringType.Normal },
            { "@\"", StringType.Normal },
            { "$\"", StringType.Interpolated },
            { "$@\"", StringType.Interpolated },
            { "@$\"", StringType.Interpolated }        
        };        

        public static IEnumerable<(string Part, CodePart Type)> GetParts(string text)
        {
            var current = string.Empty;
            while (!string.IsNullOrEmpty(text))
            {
                var word = FindNextWord(text, out StringType stringType);
                text = RemoveFromStart(text, word);

                switch (stringType)
                {
                    case StringType.Normal:
                        if (!string.IsNullOrEmpty(current))
                        {
                            yield return (current, CodePart.Text);
                            current = string.Empty;
                        }
                        yield return (word, CodePart.String);
                        break;
                    case StringType.Interpolated:
                        if (!string.IsNullOrEmpty(current))
                        {
                            yield return (current, CodePart.Text);
                            current = string.Empty;
                        }
                        foreach (var (part, type) in ParseInterpolatedString(word))
                        {
                            yield return (part, type);
                        }
                        break;
                    case StringType.None:
                        if (_keyWords.Contains(word))
                        {
                            if (!string.IsNullOrEmpty(current))
                            {
                                yield return (current, CodePart.Text);
                                current = string.Empty;
                            }
                            yield return (word, CodePart.Keyword);
                        }
                        else if (_controlKeyWords.Contains(word))
                        {
                            if (!string.IsNullOrEmpty(current))
                            {
                                yield return (current, CodePart.Text);
                                current = string.Empty;
                            }
                            yield return (word, CodePart.ControlKeyword);
                        }
                        else if (IsMethodStart(current, text.FirstOrDefault()))
                        {
                            if (!string.IsNullOrEmpty(current))
                            {
                                yield return (current, CodePart.Text);
                                current = string.Empty;
                            }
                            yield return (word, CodePart.Method);
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
                yield return (current, CodePart.Text);
            }
        }

        private static bool IsMethodStart(string current, char nextChar)
        {
            return nextChar == '(' &&
                (string.IsNullOrEmpty(current)
                || current.EndsWith(' ')
                || current.EndsWith('.'));
        }

        private static IEnumerable<(string Part, CodePart Type)> ParseInterpolatedString(string word)
        {
            var interpolated = word.Split('{', '}');
            bool inside = false;
            foreach (var i in interpolated)
            {
                if (inside)
                {
                    foreach (var p in GetParts($"{{{i}}}"))
                    {
                        yield return p;
                    }
                }
                else
                {
                    yield return (i, CodePart.String);
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

        private static string FindNextWord(string text, out StringType stringType)
        {
            
            if (string.IsNullOrEmpty(text))
            {
                stringType = StringType.None;
                return string.Empty;
            }

            var word = string.Empty;
            var starter = StringStarters.FirstOrDefault(s => text.StartsWith(s.Key));
            stringType = starter.Value;

            if (stringType != StringType.None)
            {
                return FindString(text, starter.Key.Length);
            }

            var firstChar = text[0];
            var special = _specials.Contains(firstChar);
            word += firstChar;            

            var found = false;
            var counter = 1;
            while (!found && counter < text.Length)
            {
                var c = text[counter];
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

            return word;
        }

        private static string FindString(string text, int start)
        {
            var next = text.IndexOf('"', start) + 1;
            var result = text.Substring(0, next);
            return result;
        }
    }
}
