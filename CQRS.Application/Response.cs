using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application
{
    public static class Response
    {
       public static  Response<TData> Failure<TData>(Error error)
        {
            return new Response<TData>(false, default, error);
        }

        public static Response<TData> Ok<TData>(TData value = default)
        {
            return new Response<TData>(true, value, null);
        }
    }

    public class Response<TData>
    {
        private TData _value;
        private bool _succeed;
        private Error _error;

        public Response(bool succeed, TData value, Error error)
        {
            _value = value;
            _succeed = succeed;
            _error = error;
        }
    }

    public class Error
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string DebugNessage { get; set; }
    }
}
