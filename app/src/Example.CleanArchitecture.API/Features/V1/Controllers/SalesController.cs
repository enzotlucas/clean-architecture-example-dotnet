namespace Example.CleanArchitecture.API.Features.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sales")]
    [Produces("application/json")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Get(int? page, int? pageCount)
        {
            var response = await _mediator.Send(new GetProductsQuery(page, pageCount));

            return Ok(response);
        }
    }
}
