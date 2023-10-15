using IoTPlatform.Models;
using IoTPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using ZstdSharp.Unsafe;

namespace IoTPlatform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FabricObjectController : ControllerBase
    {
        private readonly MongoDBService _service;
        
        public FabricObjectController(MongoDBService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<FabricObject>> Get()
        {
            return await _service.GetFabricObjects();
        }
        
    }
}

