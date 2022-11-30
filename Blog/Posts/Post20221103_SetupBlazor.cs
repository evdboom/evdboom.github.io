using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Code;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Header;
using OptionA.Blog.Components.Icon;
using OptionA.Blog.Components.Image;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.List;
using OptionA.Blog.Components.Table;

namespace Blog.Posts
{
    public class Post20221103_SetupBlazor : Post
    {
        public override void OnBuildPost(PostBuilder builder)
        {
            builder
                .WithDate(2022, 11, 3)
                .WithTitle("My first Blog post")
                .WithSubtitle("This post is about setting everyting up correctly")
                .WithTags("blazor", "setup")
                .AddParagraph("If i place tags <div>test me</div> here what happens?")
                .CreateHeader()
                    .OfSize(HeaderSize.One)
                    .CreateBlock()
                        .AddIcon("bi bi-check-circle")
                        .AddContent("Option A")
                        .Build()
                    .CreateBlock()
                        .AddIcon("bi bi-circle")
                        .AddContent("Option B")
                        .Build()
                    .Build()
                .AddHeader("Test header", HeaderSize.Three)
                .CreateParagraph()
                    .WithStyle(Style.StrikeThrough | Style.UpperCase)
                    .WithText("Lorum ipsum something more")
                    .Build()
                .CreateParagraph()
                    .AddContent("Some text")
                    .AddSpace()
                    .AddLink("link", "https://www.nu.nl")
                    .Build()
                .AddQuote("This is MY blog", "Erik", "https://option-a.tech")
                .AddCode(CodeLanguage.CSharp, """
                    {
                        SomeFunction.CallMe();
                        var x = 12;
                        Label y = *M*typeof(Test)*M*;
                        Labeler z = nameof(Label);
                        return x;
                        var testMeAsweel = *M*$"{a*M*a} *M*asn*M* more text";
                        var testMeMore*M* = "yo yo sem";*M*
                        var hard = @"multi
                        line
                        string";
                    }
                    """)
                .AddCode(CodeLanguage.Html, """
                    @using Blog.Navigation
                    @inherits LayoutComponentBase

                    <div class="page">
                        <NavMenu />
                        <main> <!-- Some comments here -->
                            <article class="content px-4">
                                <div class="row">
                                    <div class="col-lg-8">
                                        @Body
                       <!--   dont want this part          </div>
                                    <div class="col-lg-4">
                                        <TagContainer />
                                        <ArchiveContainer />                    
                                   --> </div> 
                                </div>            
                            </article>
                        </main>
                    </div>
                    """)
                .CreateTable()
                    .WithColumns("First", "Second", string.Empty)
                    .AddStyle(Style.StrikeThrough)
                    .AddRow("test", 23, true)
                    .RemoveStyle(Style.StrikeThrough)
                    .AddRow("Mijn naam is haas", "pie", false)
                    .AddRow("temp", null, true)
                    .Build()
                .AddImage("OptionALogoFull.png", "Something only we know")
                .AddParagraph("This was all made using just this code:")
                .AddImage("postcontent.png")
                .AddFooter("Might need more work")
                .RemoveStyle(Style.Bold)
                .CreateList()
                    .WithBlockType(BlockType.Content)
                    .AddRow("item 1")
                    .AddRow(4)
                    .AddRow("applePie")
                    .Build()
                .CreateList()
                    .IsOrdered(true)
                    .WithBlockType(BlockType.Content)
                    .WithListStyle(ListStyle.UpperRoman)
                    .AddRow("item 1")
                    .AddRow(4)
                    .AddRow("cherry pie")
                    .Build()
                .CreateOrderedList(4)
                    .AddRow("item 1")
                    .AddRow(4)
                    .AddRow("on top?")
                    .Build();
        }
    }
}
