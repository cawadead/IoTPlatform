using IoTPlatform.Models.Database;
using IoTPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IoTPlatform.Controllers
{
    [ApiController]
    public class FabricObjectController : ControllerBase
    {
        private readonly MongoDBService _service;

        public FabricObjectController(MongoDBService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("[controller]/")]
        public async Task<List<FabricObject>> GetAllFabricObjects()
        {
            return await _service.GetAllFabricObjects();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<List<FabricObject>> GetFabricObjectById(
            [Required] string id)
        {
            return await _service.GetFabricObjectById(id);
        }

        [HttpGet]
        [Route("[controller]/name={name}")]
        public async Task<List<FabricObject>> GetFabricObjects(
            [Required] string name)
        {
            return await _service.GetFabricObjects(name);
        }

        [HttpGet]
        [Route("[controller]/type={type}")]
        public async Task<List<FabricObject>> GetFabricObjects(
            [Required] int type)
        {
            return await _service.GetFabricObjects(type);
        }

        [HttpGet]
        [Route("[controller]/parentId={parentId}")]
        public async Task<List<FabricObject>> GetFabricObjectsByParentId(
            [Required] string parentId)
        {
            return await _service.GetFabricObjectsByParentId(parentId);
        }
    }
}

