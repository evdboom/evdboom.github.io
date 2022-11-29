namespace OptionA.Blog.Components.Code
{
    /// <summary>
    /// Parts of a code block for display
    /// </summary>
    public enum CodePart
    {
        /// <summary>
        /// Generic, regular text
        /// </summary>
        Text,
        /// <summary>
        /// string, usually encompassed by " characters
        /// </summary>
        String,
        /// <summary>
        /// Method or function
        /// </summary>
        Method,
        /// <summary>
        /// Language keyword
        /// </summary>
        Keyword,
        /// <summary>
        /// Language controll keyword
        /// </summary>
        ControlKeyword,
        /// <summary>
        /// Piece of comment in code
        /// </summary>
        Comment,
        /// <summary>
        /// Attribute of an element
        /// </summary>
        Attribute,
        /// <summary>
        /// Blazor component
        /// </summary>
        Component,
        
    }
}
