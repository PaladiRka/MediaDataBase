using Media.Domain.Contracts;

namespace Media.Domain
{
    public class Podcast : IAlbumContainer
    {
        //идентификатор
        public int Id { get; set; }
        
        //Название книги
        public string Title { get; set; }
        
        //Автор
        public string Author { get; set; }

        //Длительность
        public int Duration { get; set; }
        public Album Album { get; set; }
        public int? AlbumId => Album.Id;

    }
}