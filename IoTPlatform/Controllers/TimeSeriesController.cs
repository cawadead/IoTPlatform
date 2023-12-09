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

        [HttpGet]
        [Route("[controller]")]
        public async Task<IEnumerable<TimeSeries>> GetAllTimeSeries(
            [Required] DateTime timeFrom, 
            [Required] DateTime timeTo)
        {
            return await _service.GetTimeSeries(timeFrom, timeTo);
        }

        [HttpGet]
        [Route("[controller]/Paginated")]
        public async Task<IEnumerable<IEnumerable<TimeSeries>>> GetAllTimeSeriesPaginated(
            [Required] DateTime timeFrom,
            [Required] DateTime timeTo,
            [Required] int pageSize)
        {
            return await _service.GetTimeSeriesPaginated(timeFrom, timeTo, pageSize);
        }

        [HttpGet]
        [Route("[controller]/Paginated/Page")]
        public async Task<IEnumerable<TimeSeries>> GetAllTimeSeriesPage(
            [Required] DateTime timeFrom, 
            [Required] DateTime timeTo,
            [Required] int pageSize,
            [Required] int pageNumber)
        {
            return await _service.GetTimeSeriesPage(timeFrom, timeTo, pageSize, pageNumber);
        }

    }
}

