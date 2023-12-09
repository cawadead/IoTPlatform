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

        /// <summary>
        /// ��������� ���� ��������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/")]
        public async Task<List<FabricObject>> GetAllFabricObjects()
        {
            return await _service.GetAllFabricObjects();
        }

        /// <summary>
        /// ��������� ������� �� id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<List<FabricObject>> GetFabricObjectById(
            [Required] string id)
        {
            return await _service.GetFabricObjectById(id);
        }

        /// <summary>
        /// ��������� ������� �� �����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/name={name}")]
        public async Task<List<FabricObject>> GetFabricObjects(
            [Required] string name)
        {
            return await _service.GetFabricObjects(name);
        }

        /// <summary>
        /// ��������� �������� �� ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/type={type}")]
        public async Task<List<FabricObject>> GetFabricObjects(
            [Required] int type)
        {
            return await _service.GetFabricObjects(type);
        }

        /// <summary>
        /// ��������� �������� �� id ��������
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/parentId={parentId}")]
        public async Task<List<FabricObject>> GetFabricObjectsByParentId(
            [Required] string parentId)
        {
            return await _service.GetFabricObjectsByParentId(parentId);
        }
    }
}

