using System;

using WebApiSample.DemoApi.DataTransferObjects.Common;

namespace WebApiSample.DemoApi.DataTransferObjects.ToDo
{
    public class ToDoDetailsResponse : BaseResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDone { get; set; }
    }
}