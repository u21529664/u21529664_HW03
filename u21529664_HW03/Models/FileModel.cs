using System.ComponentModel.DataAnnotations;
using System.Web;


namespace u21529664_HW03.Models
{
    public class FileModel
    {
        [Display(Name = "File Name")] //Add as decorator
        public string FileName{ get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "files")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}