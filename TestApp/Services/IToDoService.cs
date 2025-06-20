using TestApp.Data;

namespace TestApp.Services
{
    public interface IToDoService : IDisposable
    {
        event Action? ItemsChanged;
        Task<List<ToDoItem>> GetForUserAsync(string userId);
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
        Task DeleteAsync(int id, string userId);
    }
}
