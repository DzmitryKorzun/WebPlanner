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

        public override bool Equals(object? obj)
        {
            return obj is BaseResponse<T> response &&
                   StatusCode == response.StatusCode &&
                   Message == response.Message &&
                   EqualityComparer<T?>.Default.Equals(Data, response.Data);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StatusCode, Message, Data);
        }
    }

    public enum ResponseStatus
    {
        OK,
        UnknownError,
        NoData,
        InternalServerError,
        InvalidPassword,
    }
}
