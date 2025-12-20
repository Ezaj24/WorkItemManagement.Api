using Microsoft.EntityFrameworkCore;
using WorkItemManagement.Api.Data;
using WorkItemManagement.Api.Models;

namespace WorkItemManagement.Api.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly AppDbContext _context;

        public WorkItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkItem>> GetAllAsync()
        {
            return await _context.WorkItems.ToListAsync();
        }

        public async Task<WorkItem?> GetByIdAsync(int id)
        {
            return await _context.WorkItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WorkItem> CreateAsync(WorkItem item)
        {
            _context.WorkItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateAsync(int id, WorkItem item)
        {
            var existing = await _context.WorkItems.FindAsync(id);
            if (existing == null)
                return false;

            existing.Title = item.Title;
            existing.Description = item.Description;
            existing.IsCompleted = item.IsCompleted;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.WorkItems.FindAsync(id);
            if (item == null)
                return false;

            _context.WorkItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
