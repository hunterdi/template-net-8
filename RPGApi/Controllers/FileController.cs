using MappingValidation.Models.Commands;
using MappingValidation.Models.Common.Behaviors;
using MappingValidation.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Common.Behaviors;
using Service.Services;

namespace RPGApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _service;

        public FileController(IFileService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<ActionResult<FileViewModel?>> Create([FromForm] FileCreateViewModel file, CancellationToken cancellationToken)
        {
            var result = await this._service.CreateAsync<FileViewModel, FileCreateViewModel>(file, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponseViewModel<FileViewModel, Guid>?>> Get([FromQuery] PagingRequestModelViewModel<FileFilterViewModel> pagingRequest, CancellationToken cancellationToken)
        {
            var result = await this._service.GetPagedAsync<FileViewModel, FileFilterViewModel>(pagingRequest, cancellationToken);

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
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromForm] FileUpdateViewModel dto, CancellationToken cancellationToken)
        {
            await this._service.UpdateAsync(id, dto, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await this._service.RemoveAsync(id, cancellationToken);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FileViewModel>> ById([FromRoute] Guid id)
        {
            var result = await this._service.GetByIdAsync<FileViewModel>(id);

            return Ok(result);
        }

        [HttpGet("async")]
        public IAsyncEnumerable<int> GetAsync() => GetDataAsync();

        private static async IAsyncEnumerable<int> GetDataAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(i));
                yield return i;
            }
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download([FromRoute] Guid id)
        {
            var result = await this._service.DownloadAsync(id);

            return File(result.Content, result.ContentType, result.RealName);
        }
    }
}
