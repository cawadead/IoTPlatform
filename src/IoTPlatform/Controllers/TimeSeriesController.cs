using IoTPlatform.Models.Database;
using IoTPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using ZstdSharp.Unsafe;

namespace IoTPlatform.Controllers
{
    [ApiController]
    public class TimeSeriesController : ControllerBase
    {
        private readonly MongoDBService _service;
        public TimeSeriesController(MongoDBService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить все записи TimeSeries в заданном временном промежутке
        /// </summary>
        /// <param name="timeFrom"></param>
        /// <param name="timeTo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]")]
        public async Task<IEnumerable<TimeSeries>> GetTimeSeries(
            [Required] DateTime timeFrom,
            [Required] DateTime timeTo)
        {
            return await _service.GetTimeSeries(timeFrom, timeTo);
        }

        /// <summary>
        /// Получить все записи TimeSeries в заданном временном промежутке в виде массивов заданного размера
        /// </summary>
        /// <param name="timeFrom"></param>
        /// <param name="timeTo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]/Paginated/List")]
        public async Task<IEnumerable<IEnumerable<TimeSeries>>> GetTimeSeriesPaginated(
            [Required] DateTime timeFrom,
            [Required] DateTime timeTo,
            [Required] int pageSize)
        {
            return await _service.GetTimeSeriesPaginated(timeFrom, timeTo, pageSize);
        }

        /// <summary>
        /// Получить страницу записей TimeSeries в заданном временном промежутке и с заданной страницей
        /// </summary>
        /// <param name="timeFrom"></param>
        /// <param name="timeTo"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/[controller]/Paginated/Page")]
        public async Task<IEnumerable<TimeSeries>> GetTimeSeriesPage(
            [Required] DateTime timeFrom,
            [Required] DateTime timeTo,
            [Required] int pageSize,
            [Required] int pageNumber)
        {
            return await _service.GetTimeSeriesPage(timeFrom, timeTo, pageSize, pageNumber);
        }

    }
}

