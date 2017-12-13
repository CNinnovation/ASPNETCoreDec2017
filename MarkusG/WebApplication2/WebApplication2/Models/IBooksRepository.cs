namespace WebApplication2.Models
{
    public interface IBooksRepository
    {
        Book GetBook(int Id,string name, int pages);
    }
}