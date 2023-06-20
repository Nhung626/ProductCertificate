using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using HoangHongNhung152465.Exceptions;

namespace HoangHongNhung152465.Filters
{
    public class SampleExceptionFilter152465De2 : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ngoại lệ có kiểm soát
            if (context.Exception is UserFriendlyException152465De2)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            else //các ngoại lệ khác
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
