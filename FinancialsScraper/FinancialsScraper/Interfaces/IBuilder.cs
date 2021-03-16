namespace FinancialsScraper.Interfaces
{
    //TODO: not sure whether i want this Covariant or not
    public interface IBuilder<T>
    {
        T Build(); 
    }
}