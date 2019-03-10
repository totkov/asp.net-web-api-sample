using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSample.DemoApi.Data;
using WebApiSample.DemoApi.DataTransferObjects.ToDo;
using WebApiSample.DemoApi.Services.Implementations;
using WebApiSample.DemoApi.Services.Interfaces;

namespace WebApiSample.DemoApi.Controllers
{
    public class ToDoController : ApiController
    {
        private IToDoService _toDoService;

        public ToDoController()
        {
            // TODO Add Ninject
            this._toDoService = new DefaultToDoService(new FakeAppDataContext());
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var result = this._toDoService.GetAll();

            if (result.IsSuccess)
                return this.Ok(result);

            return this.BadRequest(((Exception) result.Errors.First()).Message);
        }

        [HttpGet]
        public IHttpActionResult Details(string id)
        {
            var result = this._toDoService.Details(id);

            if (result.IsSuccess)
                return this.Ok(result);

            return this.BadRequest(((Exception)result.Errors.First()).Message);
        }

        [HttpPost]
        public IHttpActionResult Create(CreateToDoRequest model)
        {
            if (this.ModelState.IsValid)
            {
                var result = this._toDoService.Create(model);

                if (result.IsSuccess)
                    return this.Ok(result);

                this.ModelState.AddModelError("Error", (Exception) result.Errors.First());
            }

            return this.BadRequest(this.ModelState);
        }

        [HttpPut]
        public IHttpActionResult Update(string id, UpdateToDoRequest model)
        {
            if (this.ModelState.IsValid)
            {
                var result = this._toDoService.Update(id, model);

                if (result.IsSuccess)
                    return this.Ok(result);

                this.ModelState.AddModelError("Error", (Exception)result.Errors.First());
            }

            return this.BadRequest(this.ModelState);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var result = this._toDoService.Delete(id);

            if (result.IsSuccess)
                return this.Ok(result);

            return this.BadRequest(((Exception)result.Errors.First()).Message);
        }
    }
}
