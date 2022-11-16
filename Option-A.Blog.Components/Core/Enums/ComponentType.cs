namespace OptionA.Blog.Components.Core.Enums
{
    /// <summary>
    /// The component types to render
    /// </summary>
    public enum ComponentType
    {
        /// <summary>
        /// A paragraph component, resulting in a &lt;p&gt; tag
        /// </summary>
        Paragraph,
        /// <summary>
        /// An image component, resulting in a &lt;img&gt; tag
        /// </summary>
        Image,
        /// <summary>
        /// A quote, a composite component to display a quote title, quote and qoute source (uses <see cref="Paragraph"/>, <see cref="Header"/> and <see cref="Line"/>)
        /// </summary>
        Quote,
        /// <summary>
        /// A block of code, text inside the code block is rendered (default in Visual Studio dark theme colors) for better readability, (uses <see cref="Paragraph"/> as a backing component)
        /// </summary>
        Code,
        /// <summary>
        /// A list of items, resulting in a &lt;ul&gt; or &lt;ol&gt; tag
        /// </summary>
        List,
        /// <summary>
        /// A table of items, resulting in a &lt;table&gt; tag
        /// </summary>
        Table,
        /// <summary>
        /// A header resulting in (depending on size) a &lt;h1&gt; tag (or &lt;h2&gt; for size 2, etc.)
        /// </summary>
        Header,
        /// <summary>
        /// A link, resulting in a &lt;a&gt; tag
        /// </summary>
        Link,
        /// <summary>
        /// A 'Line' or part of a line, depending on the <see cref="BlockType"/> resulting in a &lt;div&gt;, &lt;span&gt; or no tag
        /// </summary>
        Line,
        /// <summary>
        /// A date to display, uses the <see cref="Line"/> as backing for display
        /// </summary>
        Date,
        /// <summary>
        /// A row, used by <see cref="Table"/> and <see cref="List"/> does not get rendered by itself by default
        /// </summary>
        Row
    }
}
