using Media.Domain.Contracts;

namespace Media.Domain
{
    public class Author : IAlbumContainer
    {
        //идентификатор
        public int Id { get; set; }

        //Имя
        public string Name { get; set; }
        
        public Album Album { get; set; }
        public int? AlbumId => Album.Id;
    }
}