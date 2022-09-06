namespace Exemplo.CRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrudController : ControllerBase
    {
        private readonly ILogger<CrudController> _logger;
        private readonly IMediator _mediator;

        public CrudController(ILogger<CrudController> logger,
                              IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProduct command)
        {
            var product = await _mediator.Send(command);

            return Created(string.Empty, product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteProduct(id));

            return success ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProducts());

            return Ok(products);
        }
    }
}