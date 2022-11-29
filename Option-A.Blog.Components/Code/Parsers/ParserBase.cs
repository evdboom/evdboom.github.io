namespace OptionA.Blog.Components.Code.Parsers
{
    /// <summary>
    /// base class for code parsers   
    /// </summary>
    public abstract class ParserBase : IParser
    {
        /// <inheritdoc/>
        public abstract IEnumerable<(string Part, CodePart Type, bool Selected)> GetParts(string code);

        /// <summary>
        /// returns the given text with the to removed removed from the start, if it is the start.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected static string RemoveFromStart(string text, string toRemove)
        {
            if (!text.StartsWith(toRemove))
            {
                throw new ArgumentException($"{toRemove} is not the start of {text})");
            }

            return text.Substring(toRemove.Length);
        }
    }
}
