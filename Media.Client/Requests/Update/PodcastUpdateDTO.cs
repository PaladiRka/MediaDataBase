using Media.Client.Requests.Create;

namespace Media.Client.Requests.Update
{
    public class PodcastUpdateDTO : PodcastCreateDTO
    {
        public int Id { get; set; }
    }
}