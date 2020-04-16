using System.ComponentModel.DataAnnotations;

namespace Media.Client.Requests.Create
{
    public class AlbumCreateDTO
    {
        //Название Библиотеки
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //Адрес
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}