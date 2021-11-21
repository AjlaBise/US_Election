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
            string path = Path.Combine(Directory.GetCurrentDirectory(), "files", file.FormFile.FileName);

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
                _exceptionRepository.Add(new Dal.Domain.Exception());
            }

            await ReadCreateCSV(file.FormFile.FileName);

            return new VoteViewModel();
        }

        public async Task<List<VoteUploadViewModel>> ReadCreateCSV(string fileName)
        {
            var newVotes = GetVotes(fileName);

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

        private List<VoteUploadViewModel> GetVotes(string fileName)
        {
            var newVotes = new List<VoteUploadViewModel>();

            var path = $"{Directory.GetCurrentDirectory()}{@"\files"}" + "\\" + fileName;

            List<string> result = new List<string>();
            string value;
            using (var reader = new StreamReader(path))

            using (TextReader fileReader = File.OpenText(path))
            {
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        value = value.Trim();
                        var isNumeric = int.TryParse(value, out _);
                        if (!isNumeric)
                        {
                            if (value.Contains("Constituency") || value.Contains("Votes") || value.Contains("Candidate"))
                            {
                                continue;
                            }
                            else if (value.Contains("New York") || value.Contains("Texas") || value.Contains("Washington"))
                            {
                                if (result.Count == 0)
                                {
                                    result.Add(value);

                                }
                                else
                                {
                                    result[0] = value;
                                }
                            }
                            else if (value.Length < 4)
                            {
                                result.Add(value);
                            }
                        }
                        else
                        {
                            result.Add(value);
                        }
                        if (result.Count == 3)
                        {
                            var newVote = new VoteUploadViewModel()
                            {
                                Electorate = result[0],
                                NumberOfVotes = result[1],
                                CandidateCode = result[2]
                            };
                            result.Clear();
                            result.Add(newVote.Electorate);
                            newVotes.Add(newVote);
                        }
                    }
                }
            }

            return newVotes;
        }
    }
}