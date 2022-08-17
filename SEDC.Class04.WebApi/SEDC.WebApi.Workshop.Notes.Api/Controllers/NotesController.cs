using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Workshop.Notes.ServiceModels.NoteModels;
using SEDC.WebApi.Workshop.Notes.Services.Interfaces;

namespace SEDC.WebApi.Workshop.Notes.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotesController : ControllerBase
        
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteServices ) { 
            _noteService = noteServices;
        }
        [HttpGet("/user/{userId}")]
        public ActionResult<IEnumerable<NoteDto>> GetNotes (int userId)
        {
            try
            {
                var note = _noteService.GetUserNotes(userId);
                return Ok(note);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}/user/{userId}")]
        public ActionResult<NoteDto> Get(int id,int userId)
        {
            try
            {
                var note = _noteService.Getnote(id, userId);
                return Ok(note);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        
    }
    
}
