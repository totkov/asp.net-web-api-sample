using WebApiSample.DemoApi.DataTransferObjects.Common;
using WebApiSample.DemoApi.DataTransferObjects.ToDo;

namespace WebApiSample.DemoApi.Services.Interfaces
{
    public interface IToDoService
    {
        AllToDoResponse GetAll();

        ToDoDetailsResponse Details(string toDoId);

        BaseResponse Create(CreateToDoRequest model);

        BaseResponse Update(string toDoId, UpdateToDoRequest model);

        BaseResponse Delete(string toDoId);
    }
}
