using System.Collections.Generic;

using WebApiSample.DemoApi.Data.Models;

namespace WebApiSample.DemoApi.Data.Common
{
    public interface IAppDataContext
    {
        IList<ToDoDatabaseModel> ToDoItems { get; }
    }
}
