namespace Blog.Examples
{
    public static class ExampleData
    {
        public static readonly List<ExampleObject> ExampleObjects =
        [
            new ExampleObject { Name = "Strawberries", Color = "Red", Value = 1 },
            new ExampleObject { Name = "Blueberries", Color = "Blue", Value = 2 },
            new ExampleObject { Name = "Raspberries", Color = "Red", Value = 3 },
            new ExampleObject { Name = "Blackberries", Color = "Black", Value = 4 }
        ];

        public static readonly Dictionary<ExampleEnum, string> EnumNameMappings = new()
        {
            { ExampleEnum.Strawberries, "Red Strawberries" },
            { ExampleEnum.Blueberries, "Blue Blueberries" },
            { ExampleEnum.Raspberries, "Red Raspberries" },
            { ExampleEnum.Blackberries, "Black Blackberries" }
        };

        public static readonly Dictionary<ExampleEnum, string> EnumTitleMappings = new()
        {
            { ExampleEnum.Strawberries, "Red, sweet and juicy" },
            { ExampleEnum.Blueberries, "Blue, sweet and juicy" },
            { ExampleEnum.Raspberries, "Red, sweet and tart" },
            { ExampleEnum.Blackberries, "Black, sweet and tart" }
        };
    }
}
