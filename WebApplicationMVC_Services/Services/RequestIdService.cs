using WebApplicationMVC.Interfaces.Interfaces;

namespace WebApplicationMVC_Services.Services
{
    public class RequestIdService : IRequestService
    {
        public string RequestId { get; } = Guid.NewGuid().ToString();
    }
}
