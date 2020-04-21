using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Media.DataAccess.Entities
{
    public class Album
    {
        public Album()
        {
            this.Track = new HashSet<Track>();
            this.Podcast = new HashSet<Podcast>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Track> Track { get; set; }
        public virtual ICollection<Podcast> Podcast { get; set; }

        //Идентификатор
        public int Id { get; set; }
        
        //Название библиотеки
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
    }
}