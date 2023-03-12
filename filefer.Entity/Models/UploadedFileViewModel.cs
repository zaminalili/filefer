using Microsoft.AspNetCore.Http;

namespace filefer.Entity.Models
{
    public class UploadedFileViewModel
    {
        public Guid UserId { get; set; }
        public string Key { get; set; }
        public IFormFile File { get; set; }
    }
}
