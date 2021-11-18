using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using US_Election.Dal.Database;
using US_Election.Dal.Services.Interface;

namespace US_Election.Dal.Services
{
    public class VoteService : IVoteService
    {
        private readonly US_ElectionDbContext _context;
        private readonly IMapper _mapper;

        public VoteService(US_ElectionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Obsolete]
        public List<Models.Vote> UploadVote(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            try
            {
                string path = hostingEnvironment.ContentRootPath + "\\files\\" + file.FileName;
                using (FileStream fileStream = System.IO.File.Create(path))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }

            var list = _context.Votes.ToList();

            return _mapper.Map<List<Models.Vote>>(list);
        }
    }
}
