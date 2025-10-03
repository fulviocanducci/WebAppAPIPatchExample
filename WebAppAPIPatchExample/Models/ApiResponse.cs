namespace WebAppAPIPatchExample.Models
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse(int statusCode, bool valid)
        {
            Data = null;
            StatusCode = statusCode;
            Valid = false;
        }

        public ApiResponse(T data, int statusCode, bool valid)
        {
            Data = data;
            StatusCode = statusCode;
            Valid = valid;
        }

        public T? Data { get; private set; }
        public int StatusCode { get; private set; }
        public bool Valid { get; private set; }

        public static ApiResponse<T> Ok(T data)
        {
            return new ApiResponse<T>(data, 200, true);
        }

        public static ApiResponse<T> NotFound()
        {
            return Fail(404);
        }

        public static ApiResponse<T> BadRequest(T data)
        {
            return Fail(data, 400);
        }

        public static ApiResponse<T> Success(T data, int statusCode)
        {
            return new ApiResponse<T>(data, statusCode, true);
        }

        public static ApiResponse<T> Fail(T data, int statusCode)
        {
            return new ApiResponse<T>(data, statusCode, false);
        }

        public static ApiResponse<T> Fail(int statusCode)
        {
            return new ApiResponse<T>(statusCode, false);
        }
    }
}
