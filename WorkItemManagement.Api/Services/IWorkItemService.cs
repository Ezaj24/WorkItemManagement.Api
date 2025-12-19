using WorkItemManagement.Api.Models;

namespace WorkItemManagement.Api.Services;

public interface IWorkItemService
{
    WorkItem CreateWorkItem(string title, string description);

    List<WorkItem> GetAllWorkItems();

    WorkItem? GetWorkItemById(int id);

    void MarkAsCompleted(int id);

}