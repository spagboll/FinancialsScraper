namespace FinancialsScraper.Interfaces
{
    public interface IBuilder<out T>
    {
        T Build(); 
    }
}