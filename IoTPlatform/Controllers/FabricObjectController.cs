using IoTPlatform.Extensions;
using IoTPlatform.Models.Database;
using IoTPlatform.Models.DTO;
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

        /// <summary>
        /// Получить все объекты
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]/")]
        public async Task<List<FabricObject>> GetAllFabricObjects()
        {
            return await _service.GetAllFabricObjects();
        }

        /// <summary>
        /// Добавить объекты
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/[controller]/")]
        public async Task<IActionResult> SetFabricObjects(List<FabricObjectDTO> list)
        {
            (var statusCode, var message) = await _service.SetFabricObjects(list);
            return StatusCode(statusCode, message);
        }

        /// <summary>
        /// Получить объект по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]/{id}")]
        public async Task<List<FabricObject>> GetFabricObjectById(
            [Required] string id)
        {
            return await _service.GetFabricObjectById(id);
        }

        /// <summary>
        /// Получить объекты с заданным именем
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]/name={name}")]
        public async Task<List<FabricObject>> GetFabricObjects(
            [Required] string name)
        {
            return await _service.GetFabricObjects(name);
        }

        /// <summary>
        /// Получить все объекты заданного типа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]/type={type}")]
        public async Task<List<FabricObject>> GetFabricObjects(
            [Required] int type)
        {
            return await _service.GetFabricObjects(type);
        }

        /// <summary>
        /// Получить объекты по Id родитеского элемента
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]/parentId={parentId}")]
        public async Task<List<FabricObject>> GetFabricObjectsByParentId(
            [Required] string parentId)
        {
            return await _service.GetFabricObjectsByParentId(parentId);
        }
    }
}

