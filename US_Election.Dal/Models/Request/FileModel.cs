using Microsoft.AspNetCore.Http;

namespace US_Election.Dal.Models.Request
{
    public class FileModel
    {
        public IFormFile FormFile { get; set; }
    }
}