using System.ComponentModel.DataAnnotations;

namespace NoteApp.Models
{
    public class SearchNotesInput
    {
        [Required]
        public int Id { get; set; }
        public string ? OrderBy { get; set; }
        public string? Color { get; set; }
    }
}
