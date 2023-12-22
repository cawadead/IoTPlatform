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
        /// Получение всех объектов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]/")]
        public async Task<List<FabricObject>> GetAllFabricObjects()
        {
            return await _service.GetAllFabricObjects();
        }

        [HttpPost]
        [Route("v1/[controller]/")]
        public async Task<IActionResult> SetFabricObjects(List<FabricObjectDTO> list)
        {
            ;
            return await _service.SetFabricObjects(list);
        }
        /// <summary>
        /// Получение объекта по id
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
        /// Получение объекта по имени
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
        /// Получение объектов по типу
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
        /// Получение объектов по id родителя
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

