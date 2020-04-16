using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Media.BLL.Contracts;
using Media.Client.DTO.Read;
using Media.Client.Requests.Create;
using Media.Client.Requests.Update;
using Media.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Media.WebAPI.Controllers
{
    [ApiController]
    [Route("api/album")]
    public class AlbumController
    {
         private ILogger<AlbumController> Logger { get; }
        private IAlbumCreateService AlbumCreateService { get; }
        private IAlbumGetService AlbumGetService { get; }
        private IAlbumUpdateService AlbumUpdateService { get; }
        private IMapper Mapper { get; }

        public AlbumController(ILogger<AlbumController> logger, IMapper mapper, IAlbumCreateService albumCreateService, IAlbumGetService albumGetService, IAlbumUpdateService albumUpdateService)
        {
            this.Logger = logger;
            this.AlbumCreateService = albumCreateService;
            this.AlbumGetService = albumGetService;
            this.AlbumUpdateService = albumUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<AlbumDTO> PutAsync(AlbumCreateDTO album)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.AlbumCreateService.CreateAsync(this.Mapper.Map<AlbumUpdateModel>(album));

            return this.Mapper.Map<AlbumDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<AlbumDTO> PatchAsync(AlbumUpdateDTO album)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.AlbumUpdateService.UpdateAsync(this.Mapper.Map<AlbumUpdateModel>(album));

            return this.Mapper.Map<AlbumDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<AlbumDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<AlbumDTO>>(await this.AlbumGetService.GetAsync());
        }

        [HttpGet]
        [Route("{albumId}")]
        public async Task<AlbumDTO> GetAsync(int albumId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {albumId}");

            return this.Mapper.Map<AlbumDTO>(await this.AlbumGetService.GetAsync(new AlbumIdentityModel(albumId)));
        }
    }
}