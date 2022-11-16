namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Interface for builders that support generic child builders, for instance <see cref="Block.BlockBuilder{Parent}"/>
    /// </summary>
    public interface IParentBuilder : IContentParentBuilder
    {
    }
}
