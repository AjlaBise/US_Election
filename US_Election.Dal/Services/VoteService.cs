using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using US_Election.Dal.Database;
using US_Election.Dal.Models;
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

        public List<Models.Vote> GetAll()
        {
            var entity = _context.Votes.ToList();

            return _mapper.Map<List<Models.Vote>>(entity);
        }

        [Obsolete]
        public List<Models.Vote> UploadVote(FileModel file)
        {
           
                string path = Path.Combine(Directory.GetCurrentDirectory(), "files", file.FileName);
                if(file.FileName.EndsWith(".csv"))
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

                var listFile = this.ReadCreateCSV(file.FileName);

                return _mapper.Map<List<Models.Vote>>(listFile);
        }

        private List<Models.VoteUploadModal> ReadCreateCSV(string fileName)
        {
            var newVotes = new List<Models.VoteUploadModal>();

            string path = $"{Directory.GetCurrentDirectory()}{@"\files"}" + "\\" + fileName;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var test = csv.GetRecord<Models.VoteUploadModal>();
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
                    var electorateId = _context.Electorates.FirstOrDefault(x=> x.Name == item.Electorate).Id;
                    
                    var votes = _context.Votes.Where(x => x.CandidateId == candidateId &&
                    x.ElectorateId == electorateId).FirstOrDefault();

                    if(votes != null)
                    {
                        votes.NumberOfVotes = int.Parse(item.numberOfVotes);
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
