using System.Collections.Generic;

namespace ConsoleApplication1
{
    public interface IElementMapper
    {
        DataElement Map(IEnumerable<string> values);
    }
}