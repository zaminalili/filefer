using filefer.Entity.Models;
using Microsoft.AspNetCore.Http;

namespace filefer.Service.Helpers
{
    public interface IFileHelper
    {
        Task<AddFileViewModel> Upload(IFormFile file);
    }
}
