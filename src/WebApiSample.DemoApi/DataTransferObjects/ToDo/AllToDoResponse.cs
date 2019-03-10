using System.Collections.Generic;

using WebApiSample.DemoApi.DataTransferObjects.Common;

namespace WebApiSample.DemoApi.DataTransferObjects.ToDo
{
    public class AllToDoResponse : BaseResponse
    {
        public IEnumerable<ToDoListItem> ToDoItems { get; set; }
    }

    public class ToDoListItem
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}