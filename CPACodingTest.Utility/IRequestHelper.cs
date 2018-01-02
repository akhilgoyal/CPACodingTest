using System.Threading.Tasks;

namespace CPACodingTest.Utility
{
    public interface IRequestHelper
    {
        Task<T> GetAsync<T>();
        
    }
}
