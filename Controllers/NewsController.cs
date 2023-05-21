using AvaTrade.Go.BFF.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvaTrade.Go.BFF.Controllers
{
    [ApiController]
    [Route("api/avatrade-go/news")]
    public class NewsController : ControllerBase
    {
        private readonly IMediator mediator;

        public NewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("filtered")]
        //[Authorize] intentionaly commented since no implementation of authorization check is present. However, in my opinion
        // the preferable way of authorizing requests is on gateway/proxy (Kong, Nginx) level. This way requests would be rejected
        // way before "touching" the API
        public async Task<IActionResult> GetAll([FromQuery] GetFilteredNews.Query query)
        {
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("latest-for-instruments")]
        public async Task<IActionResult> GetLatestForLatestInstruments()
        {
            var result = await mediator.Send(new GetLatestNewsForInstruments.Query());

            return Ok(result);
        }
    }
}