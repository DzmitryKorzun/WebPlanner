using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlanner.Service
{
    public class BaseResponse<T>
    {
        public ResponseStatus StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    public enum ResponseStatus
    {
        OK,
        UnknownEror,
        NoData,
        InternalServerError
    }
}
