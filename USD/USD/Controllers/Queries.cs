#region References
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using USD.Models;
using USD.Service;
using static USD.Models.Request;
#endregion

namespace USD.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<Root>))]
    public class Queries : ControllerBase
    {
        private readonly IServiceConsult _serviceConsult = null;
        public Queries(IServiceConsult serviceConsult) =>  _serviceConsult = serviceConsult;

        /// <summary>
        /// Obtener datos de BVC
        /// </summary>
        /// <returns>return data</returns>
        [ActionName(nameof(GetConsult))]
        [HttpGet(Name = nameof(GetConsult))]
        public async Task<IActionResult> GetConsult()
        {
            try
            {
                var request = await _serviceConsult.Get();
                var response = new ApiResponse<Root>(request);
                return Ok(response);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
