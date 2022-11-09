﻿namespace Blog.PostComponents.Line
{
    public class LineContent : PostItemContent
    {
        public override ComponentType Type => ComponentType.Line;
        public override bool SupportsCustomChildContent => true;
    }
}
