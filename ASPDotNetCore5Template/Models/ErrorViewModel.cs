
namespace ASPDotNetCore5Template.Models
{
    public class ErrorViewModel
    {
        public int Code { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId()
        {
            return !string.IsNullOrEmpty(RequestId);
        }
    }
}
