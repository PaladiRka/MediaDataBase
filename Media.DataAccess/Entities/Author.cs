using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Media.DataAccess.Entities
{
    public class Author
    {
        public Author()
        {
            this.Track = new HashSet<Track>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Track> Track { get; set; }

        //Идентификатор
        public int Id { get; set; }

        public string Name { get; set; }

    }
}