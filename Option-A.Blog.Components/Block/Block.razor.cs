using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionA.Blog.Components.Block
{
    /// <summary>
    /// Block component
    /// </summary>
    public partial class Block
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public BlockContent? Content { get; set; }
    }
}
