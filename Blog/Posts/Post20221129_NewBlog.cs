using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Link;

namespace Blog.Posts
{
    public class Post20221129_NewBlog : Post
    {
        public override void OnBuildPost(PostBuilder builder)
        {
            builder
                .WithDate(2022, 11, 29)
                .WithTitle("Blog in Blazor")
                .WithSubtitle("A new blog with a custom blazor building engine")
                .WithTags("blazor")
                .AddParagraph("Welcome to my new blog.")
                .CreateParagraph()
                    .AddContent("A while ago I decided to start blogging about my journey learning and building in .Net (well mostly, not everything will be .Net specific). I was advised by a fellow course participant, ").AddLink("Niels", "https://nielskok.tech").AddContent(", of the course we were following (Certified Technical Trainer) to use ").AddLink("GitHub pages", "https://pages.github.com/").AddContent(" to post the blog.")
                    .Build()
                .CreateParagraph()
                    .AddContent("When looking into GitHub pages there is an tutorial of using Jekyll, a static site generator, to generate te blog from ").AddLink("Markdown", "https://en.wikipedia.org/wiki/Markdown").AddContent(" files. However I found setting up Jekyll and building a bit of a hassle, as Jekyll states that \"Windows is not an officially-supported platform\". Now folling the guide I did get it up and running, but it did not feel quite right, and I missed some customization options (which problably are there, I just didn't really look into it). So.. building a blog about .Net and Blazor, why not build it in blazor.")
                    .Build()
                .CreateParagraph()
                    .AddContent("Therefore I decided to build my own blog rendering engine to built this. And while there is still a lot to improve, I'm proud of the result so far. The results and current version can be seen on ").AddLink("GitHub", "https://github.com/evdboom/evdboom.github.io/tree/main/Option-A.Blog.Components").AddContent(".")
                    .Build()
                ;
        }
    }
}

