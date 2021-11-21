using Microsoft.AspNetCore.Http;

namespace US_Election.Dal.Models.Request
{
    public class FileModel
    {
        public string FileName { get; set; }

        public IFormFile FormFile { get; set; }
    }
}