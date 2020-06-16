using EasyCaching.Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RedisIntroduction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedisController : ControllerBase
    {
        private IEasyCachingProvider _cachingProvider;
        private IEasyCachingProviderFactory _cachingProviderFactory;

        public RedisController(IEasyCachingProviderFactory cachingProviderFactory)
        {
            _cachingProviderFactory = cachingProviderFactory;
            _cachingProvider = cachingProviderFactory.GetCachingProvider("redis1");
        }

        [HttpGet("set")]
        public IActionResult SetItemInQueue()
        {
            _cachingProvider.Set("Testkey123", "Here is my value", TimeSpan.FromDays(100));

            return Ok();
        }

        [HttpGet("get")]
        public IActionResult GetItemInQueue()
        {
            var item = _cachingProvider.Get<string>("Testkey123");

            return Ok(item);
        }

    }
}
