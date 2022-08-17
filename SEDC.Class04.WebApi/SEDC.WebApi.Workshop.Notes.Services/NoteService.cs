using SEDC.WebApi.Workshop.Notes.Common.Map_Helpers;
using SEDC.WebApi.Workshop.Notes.DataAccess;
using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using SEDC.WebApi.Workshop.Notes.ServiceModels.NoteModels;
using SEDC.WebApi.Workshop.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.Services
{
    public class NoteService : INoteService
    {
        public NoteService(IRepository<Note> noteRepository)
        {
            NoteRepository = noteRepository;
        }

        public IRepository<Note> NoteRepository { get; }

        public NoteDto Getnote(int id, int userId)
        {
            var note = NoteRepository
                .FilterBy(x => x.Id == id && x.UserId == userId)
                .FirstOrDefault();
            if(note == null)
            {
                throw new Exception("Note not found");
            }
            return note.Map();
           
        }

        public IEnumerable<NoteDto> GetUserNotes(int userId)
        {
            return NoteRepository
                .FilterBy(x => x.UserId == userId)
                .Select(x => x.Map());
        }
    }
}
