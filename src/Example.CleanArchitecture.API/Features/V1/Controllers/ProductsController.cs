namespace Example.CleanArchitecture.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateProductCommand product)
        {
            var response = await _mediator.Send(product);

            return CreatedAtAction(nameof(Post), response);
        }
    }
}
