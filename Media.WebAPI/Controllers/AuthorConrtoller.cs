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
    [Route("api/author")]
    public class AuthorController
    {
        private ILogger<AuthorController> Logger { get; }
        private IAuthorCreateService AuthorCreateService { get; }
        private IAuthorGetService AuthorGetService { get; }
        private IAuthorUpdateService AuthorUpdateService { get; }
        private IMapper Mapper { get; }

        public AuthorController(ILogger<AuthorController> logger, IMapper mapper, IAuthorCreateService authorCreateService, IAuthorGetService authorGetService, IAuthorUpdateService authorUpdateService)
        {
            this.Logger = logger;
            this.AuthorCreateService = authorCreateService;
            this.AuthorGetService = authorGetService;
            this.AuthorUpdateService = authorUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<AuthorDTO> PutAsync(AuthorCreateDTO author)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.AuthorCreateService.CreateAsync(this.Mapper.Map<AuthorUpdateModel>(author));

            return this.Mapper.Map<AuthorDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<AuthorDTO> PatchAsync(AuthorUpdateDTO author)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.AuthorUpdateService.UpdateAsync(this.Mapper.Map<AuthorUpdateModel>(author));

            return this.Mapper.Map<AuthorDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<AuthorDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<AuthorDTO>>(await this.AuthorGetService.GetAsync());
        }

        [HttpGet]
        [Route("{authorId}")]
        public async Task<AuthorDTO> GetAsync(int authorId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {authorId}");

            return this.Mapper.Map<AuthorDTO>(await this.AuthorGetService.GetAsync(new AuthorIdentityModel(authorId)));
        }
    }
}