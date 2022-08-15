using Microsoft.AspNetCore.Mvc;
using NoteApp.Models;

namespace NoteApp.Controllers
{
 //Fluent Validation

  [ApiController]
    [Route("api/v1/{controller}")]

  
    public class Notescontroller : ControllerBase
    {
        private readonly List<note> _notes = new List<note>
    {
        new note
        {
            Id = 1,
            Text ="Beautiful Day",
            Color ="Orange",
            UserId = 1,
        },
        new note
        {
            Id = 2,
            Text = "Good Bye",
            Color = "Red",
            UserId = 0,
        },
        new note
        {
            Id=3,
            Text = "Garden",
            Color ="green",
            UserId = 1,
        }
    };
        [HttpGet]
        [Route("id/{id}")]
        public  ActionResult<note> GetById(int id)
        {
            var note =   _notes.FirstOrDefault(x => x.Equals(id));
            if(note == null)
            {
                return NotFound("Note doesn't exists");
            }
            return Ok(note);
        }

        [HttpGet]
        public ActionResult<IEnumerable<note>> GetList([FromQuery]string? orderBy)
        {
            var a = Request;
            var b = Response;
            IEnumerable<note> notes = _notes;
            switch (orderBy)
            {
                case "Beautiful Day":
                    notes = notes.OrderBy(x => x.Text);
                    break;
                case "Garden":
                    notes = notes.OrderBy(x => x.Color);
                    break;
            }

            return Ok(_notes);
        }

        [HttpGet("user/{userId}/notes")]
        public ActionResult<IEnumerable<note>> GetNotesForUser([FromRoute]int userId,[FromQuery] SearchNotesInput input)
        {
           if(ModelState.IsValid)
            {
                var test = "test";
            }
            var notes = _notes.Where(x => x.UserId == userId);
                if (!string.IsNullOrWhiteSpace(input.Color))
            {
                notes = notes.Where(x => x.Color == input.Color);   
            }
            switch (input.OrderBy)
            {
                case "Beautiful Day":
                    notes = notes.OrderBy(x => x.Text);
                    break;
                case "Garden":
                    notes = notes.OrderBy(x => x.Color);
                    break;
            }
            return Ok(notes);
        }

        [HttpGet("user/{userId}/notesForUser")]
        public ActionResult<IEnumerable<note>> GetNotesForLoggedUser([FromRoute]int userId,[FromHeader] int? authenticatedUser)
        {
            
            if(authenticatedUser is null)
            {
                return Unauthorized();
            }
            if(authenticatedUser != userId)
            {
                return StatusCode(403," you can't acess notes for this user");
            }
            return Ok(_notes.Where(x => x.UserId == userId));
        }


    }
}
