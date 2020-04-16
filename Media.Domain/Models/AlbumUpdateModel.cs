using Media.Domain.Contracts;

namespace Media.Domain.Models
{
    public class AlbumUpdateModel : IAlbumIdentity
    {
        public int Id { get; set; }
        
        //Название библиотеки
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
    }
}