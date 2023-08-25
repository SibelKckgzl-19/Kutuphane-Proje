using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.ApiResponses
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public List<string>? ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> Success(int statusCode, T data) 
        {
            return new ApiResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
            };
        }

        public static ApiResponse<T> Success(int statusCode)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
            };
        }

        public static ApiResponse<T> Fail(int statusCode, List<string> errorMessage)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };
            
        }
        public static ApiResponse<T> Fail(int statusCode, string errorMessage)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMessage = new List<string> { errorMessage }
            };
        }
    }
}
