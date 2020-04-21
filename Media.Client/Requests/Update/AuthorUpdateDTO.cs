using Media.Client.Requests.Create;

namespace Media.Client.Requests.Update
{
    public class AuthorUpdateDTO : AuthorCreateDTO
    {
        public int Id { get; set; }
    }
}