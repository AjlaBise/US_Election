using AutoMapper;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using US_Election.Dal.Database;
using US_Election.Dal.Models.Request;
using US_Election.Dal.Services.Interface;

namespace US_Election.Dal.Services
{
    public class VoteRepository : IVoteRepository
    {
        private readonly US_ElectionDbContext _context;
        private readonly IMapper _mapper;

        public VoteRepository(US_ElectionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Models.VoteViewModel>> GetAll()
        {
            var entity = await _context.Votes.ToListAsync();

            return _mapper.Map<List<Models.VoteViewModel>>(entity);
        }

        [Obsolete]
        public Models.VoteViewModel UploadVote(FileModel file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "files", file.FileName);

            string ext = Path.GetExtension(file.FormFile.FileName);

            if (ext == ".csv")
            {
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
            }
            else
            {
                var Error = new Database.Exception();
                Error.ErrorMessage = "Please select correct format of the file!";
                _context.Exceptions.Add(Error);
                _context.SaveChanges();
            }

            ReadCreateCSV(file.FileName);

            return new Models.VoteViewModel();
        }

        private List<Models.VoteUploadViewModel> ReadCreateCSV(string fileName)
        {
            var newVotes = new List<Models.VoteUploadViewModel>();

            string path = $"{Directory.GetCurrentDirectory()}{@"\files"}" + "\\" + fileName;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var test = csv.GetRecord<Models.VoteUploadViewModel>();
                    newVotes.Add(test);
                }
            }

            path = $"{Directory.GetCurrentDirectory()}{@"\files"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            {
                using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(newVotes);
                }
            }

            if (newVotes.Count() > 0)
            {
                foreach (var item in newVotes)
                {
                    var candidateId = _context.Candidates.FirstOrDefault(e => e.Code == item.CandidateCode).Id;
                    var electorateId = _context.Electorates.FirstOrDefault(x => x.Name == item.Electorate).Id;

                    var votes = _context.Votes.Where(x => x.CandidateId == candidateId &&
                    x.ElectorateId == electorateId).FirstOrDefault();

                    if (votes != null)
                    {
                        votes.NumberOfVotes = int.Parse(item.NumberOfVotes);
                        votes.OverrideFile = true;

                        _context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("err");
                    }
                }
            }

            return newVotes;
        }
    }
}