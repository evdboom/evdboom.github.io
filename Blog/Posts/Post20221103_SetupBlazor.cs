﻿using Blog.Builders;
using Blog.Enums;
using Blog.PostComponents;
using Blog.PostComponents.Code;
using Blog.PostComponents.Header;
using Blog.PostComponents.Line;
using Blog.PostComponents.Link;
using Blog.PostComponents.Paragraph;
using Blog.PostComponents.Quote;
using Blog.PostComponents.Table;

namespace Blog.Posts
{
    public class Post20221103_SetupBlazor : IPost
    {
        public PostItem Post { get; }

        public Post20221103_SetupBlazor()
        {
            Post = PostBuilder
            .CreatePost()
            .WithDate(2022, 11, 3)
            .WithTitle("My first Blog post")
            .WithSubTitle("This post is about setting everyting up correctly")
            .SetStyle(Style.Bold)
            .AddParagraph("If i place tags <div>test me</div> here what happens?")
            .AddHeader("Test header", HeaderSize.Three, Style.Bold | Style.Italic)
            .AddParagraph("Lorum ipsum something more", Style.StrikeThrough | Style.UpperCase)
            .ResetStyle()
            .StartParagraph()
                .SetJustContent()
                .AddLine("Some text")
                .AddSpace()
                .AddLink("link", "https://www.nu.nl")
                .SetBlocks()
            .EndParagraph()
            .AddQuote("This is MY blog", "Erik", "https://option-a.text")
            .AddCode("c#", """
                           {
                               SomeFunction.CallMe();
                               var x = 12;
                               Label y = typeof(Test);
                               Labeler z = nameof(Label);
                               return x;
                               var testMeAsweel = $"{aa} asn more text";
                               var testMeMore = "yo yo sem";
                           }
                           """)
            .CreateTable()
                .WithCaption("This is a table")
                .AddColumns("First", "Second", string.Empty)
                .SetStyle(Style.StrikeThrough)
                .AddRow("test", 23, true)
                .ResetStyle()
                .AddRow("Mijn naam is haas", "pie", false)
                .AddRow("temp", null, true)
                .Build()
            .Build();
        }
    }
}
