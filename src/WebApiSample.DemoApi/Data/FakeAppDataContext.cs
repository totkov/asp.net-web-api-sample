using System.Collections.Generic;

using WebApiSample.DemoApi.Data.Common;
using WebApiSample.DemoApi.Data.Models;

namespace WebApiSample.DemoApi.Data
{
    public class FakeAppDataContext : IAppDataContext
    {
        private static IList<ToDoDatabaseModel> toDoItems;

        static FakeAppDataContext()
        {
            toDoItems = new List<ToDoDatabaseModel>();
        }

        public IList<ToDoDatabaseModel> ToDoItems
        {
            get { return toDoItems; }
        }
    }
}