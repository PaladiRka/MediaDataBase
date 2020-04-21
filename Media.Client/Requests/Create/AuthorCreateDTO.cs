using System.ComponentModel.DataAnnotations;

namespace Media.Client.Requests.Create
{
    public class  AuthorCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}