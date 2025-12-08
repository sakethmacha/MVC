using WebApplicationMVC.Interfaces.Interfaces;

namespace WebApplicationMVC.Services.Services
{
    public class RequestIdService : IRequestService
    {
        public string RequestId { get; } = Guid.NewGuid().ToString();
    }
}
