﻿namespace Blog.Enums
{
    [Flags]
    public enum Style
    {
        Normal = 1,
        Bold = 2,
        Italic = 4,
        Underline = 8,
        StrikeThrough = 16,
        LowerCase = 32,
        UpperCase = 64,
        Monospace = 128,
        Bordered = 256,
        Padded = 512,
        Dark = 1024,
        FloatRight = 2048,
        KeepWhiteSpace = 4096,
    }
}
