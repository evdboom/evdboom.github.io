namespace Blog.PostComponents
{
    public abstract class PostBase : IPost
    {
        public PostItem Post { get; }

        public PostBase()
        {
            Post = GeneratePost();
        }

        protected abstract PostItem GeneratePost();
    }
}
