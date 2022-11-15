using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionA.Blog.Components.Code.Parsers
{
    public interface IParser
    {
        IEnumerable<(string Part, CodePart Type)> GetParts(string text);
    }
}
