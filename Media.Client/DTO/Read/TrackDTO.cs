namespace Media.Client.DTO.Read
{
    public class TrackDTO
    {
        //идентификатор
        public int Id { get; set; }
        
        //Название книги
        public string Title { get; set; }

        //Автор
        public string Author { get; set; }

        //Возрастное ограничение
        public int Duration { get; set; }

        public AlbumDTO Album { get; set; }
    }
}