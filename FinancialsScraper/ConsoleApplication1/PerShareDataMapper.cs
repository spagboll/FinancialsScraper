using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AngleSharp.Common;

namespace ConsoleApplication1
{
    public class PerShareDataMapper : IElementMapper
    {
        public DataElement Map(IEnumerable<string> values)
        {
            return new PerShareData();
        }
    }
}