namespace ConsoleApplication1
{
    public class MapperFactory
    {
        public IElementMapper GetMapper<T>()
        {
            if (typeof(T) == typeof(PerShareData))
            {
                return new PerShareDataMapper();
            }

            return null;
        }
    }
}