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
    [Route("api/track")]
    public class TrackController
    {
        private ILogger<TrackController> Logger { get; }
        private ITrackCreateService TrackCreateService { get; }
        private ITrackGetService TrackGetService { get; }
        private ITrackUpdateService TrackUpdateService { get; }
        private IMapper Mapper { get; }

        public TrackController(ILogger<TrackController> logger, IMapper mapper, ITrackCreateService trackCreateService, ITrackGetService trackGetService, ITrackUpdateService trackUpdateService)
        {
            this.Logger = logger;
            this.TrackCreateService = trackCreateService;
            this.TrackGetService = trackGetService;
            this.TrackUpdateService = trackUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<TrackDTO> PutAsync(TrackCreateDTO track)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.TrackCreateService.CreateAsync(this.Mapper.Map<TrackUpdateModel>(track));

            return this.Mapper.Map<TrackDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<TrackDTO> PatchAsync(TrackUpdateDTO track)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.TrackUpdateService.UpdateAsync(this.Mapper.Map<TrackUpdateModel>(track));

            return this.Mapper.Map<TrackDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<TrackDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<TrackDTO>>(await this.TrackGetService.GetAsync());
        }

        [HttpGet]
        [Route("{trackId}")]
        public async Task<TrackDTO> GetAsync(int trackId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {trackId}");

            return this.Mapper.Map<TrackDTO>(await this.TrackGetService.GetAsync(new TrackIdentityModel(trackId)));
        }
    }
}