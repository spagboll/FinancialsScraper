using System.Collections.Generic;

namespace ConsoleApplication1
{
    public interface IDataElement
    {
        IDataElement Map(IEnumerable<string> data);

        string GetSelector();
    }
}