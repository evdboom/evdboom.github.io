namespace OptionA.Blog.Components.Code.Parsers
{
    /// <summary>
    /// Interface for code parsers
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses the code into code parts for seperate handling.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<(string Part, CodePart Type)> GetParts(string code);
    }
}
