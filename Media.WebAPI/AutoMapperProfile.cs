using AutoMapper;
using Media.Client.DTO.Read;
using Media.Client.Requests.Create;
using Media.Client.Requests.Update;
using Media.Domain.Models;

namespace Media.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Album, Domain.Album>();
            this.CreateMap<DataAccess.Entities.Track, Domain.Track>();
            this.CreateMap<DataAccess.Entities.Podcast, Domain.Podcast>();

            this.CreateMap<Domain.Album, AlbumDTO>();
            this.CreateMap<Domain.Track, TrackDTO>();
            this.CreateMap<Domain.Podcast, PodcastDTO>();

            this.CreateMap<AlbumCreateDTO, AlbumUpdateModel>();
            this.CreateMap<AlbumUpdateDTO, AlbumUpdateModel>();
            this.CreateMap<AlbumUpdateModel, DataAccess.Entities.Album>();
            
            this.CreateMap<TrackCreateDTO, TrackUpdateModel>();
            this.CreateMap<TrackUpdateDTO, TrackUpdateModel>();
            this.CreateMap<TrackUpdateModel, DataAccess.Entities.Track>();

            this.CreateMap<PodcastCreateDTO, PodcastUpdateModel>();
            this.CreateMap<PodcastUpdateDTO, PodcastUpdateModel>();
            this.CreateMap<PodcastUpdateModel, DataAccess.Entities.Podcast>();
        }
    }
}