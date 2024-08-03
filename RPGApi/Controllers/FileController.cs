using MappingValidation.Models.Commands;
using MappingValidation.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Business.Services;
using Domain.Behaviors;

namespace RPGApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _service;

        public FileController(IFileService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<FileQuery?>> Create([FromForm] FileCreateCommand file, CancellationToken cancellationToken)
        {
            var result = await _service.CreateAsync<FileQuery, FileCreateCommand>(file, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PageQuery<FileQuery, long>?>> Get([FromQuery] PageCommand<FileFilterCommand> pagingRequest, CancellationToken cancellationToken)
        {
            var result = await _service.GetPagedAsync<FileQuery, FileFilterCommand>(pagingRequest, cancellationToken);

            var metadata = new
            {
                result.TotalRecords,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasPrevious,
                result.HasNext,
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] long id, [FromForm] FileUpdateCommand command, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(id, command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            await _service.RemoveAsync(id, cancellationToken);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FileQuery>> ById([FromRoute] long id)
        {
            var result = await _service.GetByIdAsync<FileQuery>(id);

            return Ok(result);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download([FromRoute] long id)
        {
            var result = await _service.DownloadAsync(id);

            return File(result.Content, result.ContentType, result.RealName);
        }
    }
}
