using Media.Client.Requests.Create;

namespace Media.Client.Requests.Update
{
    public class TrackUpdateDTO : TrackCreateDTO
    {
        public int Id { get; set; }
    }
}