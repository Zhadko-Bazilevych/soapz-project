namespace SOAPZ_Book.Common
{
    public class BaseResponse
    {
        public int Code { get; set; } = 200;
        public string? Message { get; set; } = null;
    }
}
