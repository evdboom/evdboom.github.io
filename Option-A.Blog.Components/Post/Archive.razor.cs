using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionA.Blog.Components.Post
{
    public partial class Archive
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
    }
}
