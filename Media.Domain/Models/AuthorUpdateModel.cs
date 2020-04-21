using Media.Domain.Contracts;

namespace Media.Domain.Models
{
    public class AuthorUpdateModel : IAuthorIdentity
    {
        public int Id { get; set; }
        
        //Имя
        public string Name { get; set; }

    }
}