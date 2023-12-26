namespace shoe_shop_be.Errors
{
    public class ApiException: Exception
    {
        public ApiException(int statusCode, string message, string details)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
        public int StatusCode { get; set; }

        public string Message { get; set; }
        public string Details { get; set; }
    }
}
