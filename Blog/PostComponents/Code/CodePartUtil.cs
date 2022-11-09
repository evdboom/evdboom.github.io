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
            '}'
        };

        public static IEnumerable<(string Part, CodePart Type)> GetParts(string text)
        {
            var lines = text.Split(Environment.NewLine);
            bool first = true;
            foreach (var line in lines)
            {
                if (!first)
                {
                    yield return (string.Empty, CodePart.NewLine);
                }
                first = false;
                
                var workLine = line;
                var current = string.Empty;
                var stringStarted = false;
                var interPolatedString = false;
                while (!string.IsNullOrEmpty(workLine))
                {
                    var word = FindNextWord(workLine, out bool special, out bool isString);
                    if (isString && !stringStarted)
                    {
                        if (!string.IsNullOrEmpty(current))
                        {
                            interPolatedString = current.EndsWith('$');
                            if (interPolatedString)
                            {
                                current = current.TrimEnd('$');
                            }

                            yield return (current, CodePart.Text);
                            current = interPolatedString
                                ? $"$"
                                : string.Empty;
                        }
                        stringStarted = true;
                        current += word;
                        workLine = RemoveFromStart(workLine, word);
                    }
                    else if (!isString && stringStarted)
                    {
                        current += word;
                        workLine = RemoveFromStart(workLine, word);
                    }
                    else if (isString && stringStarted)
                    {
                        stringStarted = false;
                        current += word;
                        workLine = RemoveFromStart(workLine, word);

                        if (interPolatedString)
                        {
                            var interpolated = current.Split('{', '}');
                            bool inside = false;
                            var beenInside = false;
                            foreach (var i in interpolated)
                            {
                                if (inside)
                                {
                                    beenInside = true;
                                    yield return ("{", CodePart.Text);
                                    foreach (var p in GetParts(i))
                                    {
                                        yield return p;
                                    }
                                    inside = false;
                                }
                                else
                                {
                                    if (beenInside)
                                    {
                                        yield return ("}", CodePart.Text);
                                        beenInside = false;
                                    }
                                    
                                    yield return (i, CodePart.String);
                                    inside = true;
                                }
                            }
                        }
                        else
                        {
                            yield return (current, CodePart.String);

                        }
                        current = string.Empty;
                    }
                    else if (special)
                    {
                        current += word;
                        workLine = RemoveFromStart(workLine, word);
                    }
                    else if (_keyWords.Contains(word))
                    {
                        if (!string.IsNullOrEmpty(current))
                        {
                            yield return (current, CodePart.Text);
                            current = string.Empty;
                        }
                        yield return (word, CodePart.Keyword);
                        workLine = RemoveFromStart(workLine, word);

                    }
                    else if (_controlKeyWords.Contains(word))
                    {
                        if (!string.IsNullOrEmpty(current))
                        {
                            yield return (current, CodePart.Text);
                            current = string.Empty;
                        }
                        yield return (word, CodePart.ControlKeyword);
                        workLine = RemoveFromStart(workLine, word);
                    }
                    else if ((string.IsNullOrEmpty(current) || current.EndsWith('.') || current.EndsWith(' ')) && workLine.StartsWith($"{word}("))
                    {
                        if (!string.IsNullOrEmpty(current))
                        {
                            yield return (current, CodePart.Text);
                            current = string.Empty;
                        }
                        yield return (word, CodePart.Method);
                        workLine = RemoveFromStart(workLine, word);
                    }
                    else
                    {
                        current += word;
                        workLine = RemoveFromStart(workLine, word);
                    }
                }
                if (!string.IsNullOrEmpty(current))
                {
                    yield return (current, CodePart.Text);
                }
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

        private static string FindNextWord(string text, out bool special, out bool isString)
        {
            if (string.IsNullOrEmpty(text))
            {
                special = false;
                isString = false;
                return string.Empty;
            }

            var word = string.Empty;

            var firstChar = text[0];
            special = _specials.Contains(firstChar);
            isString = firstChar == '"';
            word += firstChar;
            if (isString)
            {
                return word;
            }

            var found = false;
            var counter = 1;
            while (!found && counter < text.Length)
            {
                var c = text[counter];
                var isSpecial = _specials.Contains(c);
                var nextString = c == '"';
                if (nextString)
                {
                    found = true;
                }
                else if (isString)
                {
                    found = true;
                }
                else if ((special && !isSpecial) || (!special && isSpecial))
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
    }
}
