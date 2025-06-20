using Microsoft.EntityFrameworkCore;
using TestApp.Data;

namespace TestApp.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationDbContext _ctx;
        public event Action? ItemsChanged;

        public ToDoService(ApplicationDbContext ctx) => _ctx = ctx;

        public Task<List<ToDoItem>> GetForUserAsync(string userId) =>
            _ctx.ToDoItems.Where(t => t.UserId == userId).ToListAsync();

        public async Task AddAsync(ToDoItem item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.UserId))
                    throw new ArgumentException("Title and UserId are required for ToDo items");
                
                _ctx.ToDoItems.Add(item);
                var result = await _ctx.SaveChangesAsync();
                
                if (result > 0)
                {
                    ItemsChanged?.Invoke();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            _ctx.ToDoItems.Update(item);
            await _ctx.SaveChangesAsync();
            ItemsChanged?.Invoke();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var t = await _ctx.ToDoItems.FindAsync(id);
            if (t?.UserId == userId)
            {
                _ctx.ToDoItems.Remove(t);
                await _ctx.SaveChangesAsync();
                ItemsChanged?.Invoke();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}