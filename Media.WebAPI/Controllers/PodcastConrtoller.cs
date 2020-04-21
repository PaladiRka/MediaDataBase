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
    [Route("api/podcast")]
    public class PodcastController
    {
        private ILogger<PodcastController> Logger { get; }
        private IPodcastCreateService PodcastCreateService { get; }
        private IPodcastGetService PodcastGetService { get; }
        private IPodcastUpdateService PodcastUpdateService { get; }
        private IMapper Mapper { get; }

        public PodcastController(ILogger<PodcastController> logger, IMapper mapper, IPodcastCreateService podcastCreateService, IPodcastGetService podcastGetService, IPodcastUpdateService podcastUpdateService)
        {
            this.Logger = logger;
            this.PodcastCreateService = podcastCreateService;
            this.PodcastGetService = podcastGetService;
            this.PodcastUpdateService = podcastUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<PodcastDTO> PutAsync(PodcastCreateDTO podcast)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.PodcastCreateService.CreateAsync(this.Mapper.Map<PodcastUpdateModel>(podcast));

            return this.Mapper.Map<PodcastDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<PodcastDTO> PatchAsync(PodcastUpdateDTO podcast)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.PodcastUpdateService.UpdateAsync(this.Mapper.Map<PodcastUpdateModel>(podcast));

            return this.Mapper.Map<PodcastDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PodcastDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<PodcastDTO>>(await this.PodcastGetService.GetAsync());
        }

        [HttpGet]
        [Route("{podcastId}")]
        public async Task<PodcastDTO> GetAsync(int podcastId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {podcastId}");

            return this.Mapper.Map<PodcastDTO>(await this.PodcastGetService.GetAsync(new PodcastIdentityModel(podcastId)));
        }
    }
}