﻿using Blog.PostComponents.Code;

namespace Blog.Unittests
{
    public class CodeUtilTests
    {
        [Fact]
        public void FindsMethodDeclaration()
        {            
            var test = "public static IEnumerable<(string Part, CodePart type)> GetParts(string text)";
            var parts = CodePartUtil.GetParts(test).ToList();
            Assert.Collection(parts, part =>
            {
                Assert.Equal("public", part.Part);
                Assert.Equal(CodePart.Keyword, part.Type);
            }, part =>
            {
                Assert.Equal(" ", part.Part);
                Assert.Equal(CodePart.Text, part.Type);
            }, part =>
            {
                Assert.Equal("static", part.Part);
                Assert.Equal(CodePart.Keyword, part.Type);
            }, part =>
            {
                Assert.Equal(" IEnumerable<(", part.Part);
                Assert.Equal(CodePart.Text, part.Type);
            }, part =>
            {
                Assert.Equal("string", part.Part);
                Assert.Equal(CodePart.Keyword, part.Type);
            }, part =>
            {
                Assert.Equal(" Part, CodePart type)> ", part.Part);
                Assert.Equal(CodePart.Text, part.Type);
            }, part =>
            {
                Assert.Equal("GetParts", part.Part);
                Assert.Equal(CodePart.Method, part.Type);
            }, part =>
            {
                Assert.Equal("(", part.Part);
                Assert.Equal(CodePart.Text, part.Type);
            }, part =>
            {
                Assert.Equal("string", part.Part);
                Assert.Equal(CodePart.Keyword, part.Type);
            }, part =>
            {
                Assert.Equal(" text)", part.Part);
                Assert.Equal(CodePart.Text, part.Type);
            });
        }

        [Fact]
        public void BigMethod()
        {
            var test = @"{
    SomeFunction.CallMe();
    var x = 12;
    Label y = typeof(Test);
    Labeler z = nameof(Label);
    return x;
    var testMeAsweel = $""{aa} asn more text"";
    var testMeMore = ""yo yo sem"";
}";
            var parts = CodePartUtil.GetParts(test).ToList();

        }
    }
}
