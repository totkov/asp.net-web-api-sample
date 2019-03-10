using System.Collections.Generic;

namespace WebApiSample.DemoApi.DataTransferObjects.Common
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }

        public IEnumerable<object> Errors { get; set; }
    }
}