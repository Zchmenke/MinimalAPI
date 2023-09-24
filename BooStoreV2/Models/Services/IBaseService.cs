using BookStoreV2.Models;

namespace BookStoreV2.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO _responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
