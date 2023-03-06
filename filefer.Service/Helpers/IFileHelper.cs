using Microsoft.AspNetCore.Http;

namespace filefer.Service.Helpers
{
    public interface IFileHelper
    {
        Task<string> Upload(IFormFile file);
    }
}
