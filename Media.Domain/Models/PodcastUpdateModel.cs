using Media.Domain.Contracts;

namespace Media.Domain.Models
{
    public class PodcastUpdateModel : IPodcastIdentity, IAlbumContainer
    {
        public int Id { get; set; }

        //Название книги
        public string Title { get; set; }

        //Автор
        public string Author { get; set; }

        //Возрастное ограничение
        public int Duration { get; set; }

        public int? AlbumId { get; set; }
    }
}