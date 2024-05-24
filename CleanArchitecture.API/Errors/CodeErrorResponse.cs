namespace CleanArchitecture.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Sent request has errors",
                401 => "Authorization required for this resource",
                404 => "Not resource found",
                500 => "Server error",
                _ => string.Empty,
            };
        }
    }
}
