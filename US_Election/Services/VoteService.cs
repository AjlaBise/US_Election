using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using US_Election.Dal.Models;
using US_Election.Dal.Models.Request;
using US_Election.Dal.Repositories.Interface;
using US_Election.Dal.Services.Interface;
using US_Election.Services.Interface;

namespace US_Election.Services
{
    public class VoteService : IVoteService
    {
        private readonly IExceptionRepository _exceptionRepository;
        private readonly IElectorateRepository _electorateRepository;
        private readonly IVoteRepository _voteRepository;

        public VoteService(
            IExceptionRepository exceptionRepository, 
            IElectorateRepository electorateRepository,
            IVoteRepository voteRepository)
        {
            _exceptionRepository = exceptionRepository;
            _electorateRepository = electorateRepository;
            _voteRepository = voteRepository;
        }

        [Obsolete]
        public async Task<VoteViewModel> UploadVote(FileModel file)
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
                _exceptionRepository.Add(new Dal.Database.Exception());
            }

            await ReadCreateCSV(file.FileName);

            return new VoteViewModel();
        }

        public async Task<List<VoteUploadViewModel>> ReadCreateCSV(string fileName)
        {
            var newVotes = new List<VoteUploadViewModel>();

            string path = $"{Directory.GetCurrentDirectory()}{@"\files"}" + "\\" + fileName;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var test = csv.GetRecord<VoteUploadViewModel>();
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
                    var electorateId = await _electorateRepository.GetElectorateId(item.Electorate);

                    await _voteRepository.Update(item.CandidateCode, electorateId, int.Parse(item.NumberOfVotes));
                }
            }

            return newVotes;
        }
    }
}