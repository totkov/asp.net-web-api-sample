using System;
using System.Collections.Generic;
using System.Linq;

using WebApiSample.DemoApi.Data.Common;
using WebApiSample.DemoApi.Data.Models;
using WebApiSample.DemoApi.DataTransferObjects.Common;
using WebApiSample.DemoApi.DataTransferObjects.ToDo;
using WebApiSample.DemoApi.Services.Interfaces;

namespace WebApiSample.DemoApi.Services.Implementations
{
    public class DefaultToDoService : IToDoService
    {
        private IAppDataContext _dc;

        public DefaultToDoService(IAppDataContext dc)
        {
            this._dc = dc;
        }

        public AllToDoResponse GetAll()
        {
            try
            {
                var result = this._dc.ToDoItems
                    .Select(todo => new ToDoListItem
                    {
                        Id = todo.Id,
                        Title = todo.Title,
                        IsDone = todo.IsDone
                    }).ToList();

                return new AllToDoResponse { IsSuccess = true, ToDoItems = result };
            }
            catch (Exception ex)
            {
                return new AllToDoResponse { IsSuccess = false, Errors = new List<object> { ex } };
            }
            
        }

        public ToDoDetailsResponse Details(string toDoId)
        {
            try
            {
                var result = this._dc.ToDoItems
                    .Where(todo => todo.Id == toDoId)
                    .Select(todo => new ToDoDetailsResponse
                    {
                        Id = todo.Id,
                        Title = todo.Title,
                        Description = todo.Description,
                        CreateDate = todo.CreateDate,
                        IsDone = todo.IsDone
                    })
                    .FirstOrDefault();

                if (result == null)
                    throw new InvalidOperationException($"Item with id {toDoId} was not found!");

                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
            {
                return new ToDoDetailsResponse { IsSuccess = false, Errors = new List<object> { ex } };
            }
        }

        public BaseResponse Create(CreateToDoRequest model)
        {
            try
            {
                var dbObject = new ToDoDatabaseModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = model.Title,
                    Description = model.Description,
                    CreateDate = model.CreateDate,
                    IsDone = model.IsDone
                };

                this._dc.ToDoItems.Add(dbObject);

                return new BaseResponse { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsSuccess = false, Errors = new List<object> { ex } };
            }
        }

        public BaseResponse Update(string toDoId, UpdateToDoRequest model)
        {
            try
            {
                var dbObject = this._dc.ToDoItems.FirstOrDefault(todo => todo.Id == toDoId);

                dbObject.Title = model.Title;
                dbObject.Description = model.Description;
                dbObject.IsDone = model.IsDone;

                return new BaseResponse { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsSuccess = false, Errors = new List<object> { ex } };
            }

        }

        public BaseResponse Delete(string toDoId)
        {
            try
            {
                var dbObject = this._dc.ToDoItems.FirstOrDefault(todo => todo.Id == toDoId);
                this._dc.ToDoItems.Remove(dbObject);

                return new BaseResponse { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsSuccess = false, Errors = new List<object> { ex } };
            }
        }
    }
}