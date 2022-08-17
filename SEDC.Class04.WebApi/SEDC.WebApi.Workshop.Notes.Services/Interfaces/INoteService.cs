using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using SEDC.WebApi.Workshop.Notes.ServiceModels.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.Services.Interfaces
{
    public interface INoteService
    {
        public NoteDto Getnote(int id, int userId);

        public IEnumerable<NoteDto> GetUserNotes(int userI);

    }
}
