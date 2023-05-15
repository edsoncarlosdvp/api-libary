using System.ComponentModel.DataAnnotations;

namespace LibaryApi.ViewModel
{
    public class LibaryViewModels
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
