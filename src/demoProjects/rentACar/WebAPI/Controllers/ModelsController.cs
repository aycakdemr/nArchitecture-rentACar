using Application.Features.Brands.Models;
using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetlistModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController :  BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetlistModelQuery getListModelQuery = new() { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody] Dynamic dynamic)
        {
            GetlistModelByDynamicQuery getListModelbyDynamicQuery = new() { PageRequest = pageRequest ,Dynamic = dynamic};
            ModelListModel result = await Mediator.Send(getListModelbyDynamicQuery);
            return Ok(result);
        }
    }
}
