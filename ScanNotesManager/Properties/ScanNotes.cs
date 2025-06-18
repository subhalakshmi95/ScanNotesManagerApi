using System.ComponentModel.DataAnnotations;

namespace ScanNotesManager.Properties
{
    public class ScanNotes
    {
        [Required(ErrorMessage = "Scan notes title is required")]
        [MinLength(1)]
        public string title {  get; set; }
        [Required(ErrorMessage = "Scan notes content is required")]
        [MinLength(1)]
        public string content { get; set; }
    }
}
