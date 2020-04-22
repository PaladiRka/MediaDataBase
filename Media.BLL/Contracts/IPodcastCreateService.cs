using System.Threading.Tasks;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Contracts
 {
     public interface IPodcastCreateService
     {
         Task<Podcast> CreateAsync(PodcastUpdateModel podcast);
     }
 }