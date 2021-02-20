using System.Collections.Generic;

namespace ConsoleApplication1
{
    public interface IElementMapper
    {
        IElementMapper Map(Dictionary<ElementName, string> values);
    }
}