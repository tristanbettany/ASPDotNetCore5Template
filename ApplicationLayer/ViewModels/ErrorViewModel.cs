
namespace ApplicationLayer.ViewModels
{
    public class ExceptionViewModel
    {
        public int Code { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId()
        {
            return !string.IsNullOrEmpty(RequestId);
        }
    }
}
