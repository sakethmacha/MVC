using WebApplicationMVC.Interfaces.Interfaces;

namespace WebApplicationMVC.Services.Services
{
    public class CounterService : ICounterService
    {
        private int _count = 0;
        public int GetCount() => ++_count;
    }
}
