using WorkItemManagement.Api.Models;

namespace WorkItemManagement.Api.Services
{
    public interface IWorkItemService
    {
        Task<List<WorkItem>> GetAllAsync();
        Task<WorkItem?> GetByIdAsync(int id);
        Task<WorkItem> CreateAsync(WorkItem item);
        Task<bool> UpdateAsync(int id, WorkItem item);
        Task<bool> DeleteAsync(int id);
    }
}
