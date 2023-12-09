using IoTPlatform.Models.Database;
using IoTPlatform.Services;
using Microsoft.AspNetCore.Mvc;


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
        public async Task<List<FabricObject>> GetAllFabricObjects()
        {
            return await _service.GetAllFabricObjects();
        }
        
    }
}

