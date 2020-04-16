using Media.Client.Requests.Create;

namespace Media.Client.Requests.Update
{
    public class AlbumUpdateDTO : AlbumCreateDTO
    {
        public int Id { get; set; }
    }
}