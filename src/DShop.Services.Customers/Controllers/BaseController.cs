using System.Threading.Tasks;
using DShop.Common.Dispatchers;
using DShop.Common.Messages;
using DShop.Common.Types;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Customers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public BaseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        protected async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _dispatcher.QueryAsync<TResult>(query);

        protected ActionResult<T> Single<T>(T data)
        {
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}