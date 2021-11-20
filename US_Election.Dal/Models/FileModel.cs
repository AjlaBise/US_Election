using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace US_Election.Dal.Models
{
    public class FileModel
    {
        public string FileName { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
