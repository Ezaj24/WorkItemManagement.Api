using WorkItemManagement.Api.Models;

namespace WorkItemManagement.Api.Services
{
    public class WorkItemService : IWorkItemService
    {
        private static readonly List<WorkItem> _workItems = new();
        private static int _idCounter = 1;
        public WorkItem CreateWorkItem(string title, string description)
        {
            var workitem = new WorkItem
            {
                Id = _idCounter++,
                Title = title,
                Description = description,
                IsComplete = false,
                CreatedAt = DateTime.UtcNow,

            };

            _workItems.Add(workitem);

            return workitem;
        }

        public List<WorkItem> GetAllWorkItems()
        {
            return _workItems;
        }

        public WorkItem? GetWorkItemById(int id)
        {
           return _workItems.FirstOrDefault(x => x.Id == id);
        }

        public void MarkAsCompleted(int id)
        {
            var workItem = _workItems.FirstOrDefault(x => x.Id == id);

            if(workItem == null)
            {
                return;
            }

            workItem.IsComplete = true;
        }
    }
}
