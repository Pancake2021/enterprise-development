using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;  // Для логирования
using UniversityStats.API.Dto;
using UniversityStats.API.Services;

namespace UniversityStats.API.Controllers
{
    /// <summary>
    /// Class for specialty's controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly SpecialtyService _service;
        private readonly ILogger<SpecialtyController> _logger;  // Логер для контроллера

        // Внедрение зависимостей через конструктор
        public SpecialtyController(SpecialtyService service, ILogger<SpecialtyController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Return list of specialties
        /// </summary>
        /// <returns> List of specialties</returns>
        [HttpGet]
        public ActionResult<IEnumerable<SpecialtyDto>> Get()
        {
            _logger.LogInformation("Fetching list of specialties.");
            var specialties = _service.GetAll();

            if (specialties == null || !specialties.Any())
            {
                _logger.LogWarning("No specialties found.");
                return NotFound();
            }

            _logger.LogInformation("Successfully fetched list of specialties.");
            return Ok(specialties);
        }

        /// <summary>
        /// Return specialty's information by specialty's id
        /// </summary>
        /// <param name="SpecialtyId">Specialty's id</param>
        /// <returns>Specialty's information</returns>
        [HttpGet("{SpecialtyId}")]
        public ActionResult<SpecialtyDto> Get(string SpecialtyId)
        {
            _logger.LogInformation($"Fetching specialty information for ID: {SpecialtyId}.");
            var specialty = _service.GetById(SpecialtyId);

            if (specialty == null)
            {
                _logger.LogWarning($"Specialty with ID {SpecialtyId} not found.");
                return NotFound();
            }

            _logger.LogInformation($"Successfully fetched specialty with ID: {SpecialtyId}.");
            return Ok(specialty);
        }

        /// <summary>
        /// Post specialty's information to database
        /// </summary>
        /// <param name="specialty">Specialty's information</param>
        /// <returns>Success or not</returns>
        [HttpPost]
        public ActionResult<SpecialtyDto> Post([FromBody] SpecialtyDto specialty)
        {
            _logger.LogInformation("Posting new specialty information.");
            _service.Post(specialty);

            // Заменили Id на SpecialtyId
            _logger.LogInformation($"Specialty with ID {specialty.SpecialtyId} was successfully posted.");
            return Ok(specialty);
        }

        /// <summary>
        /// Correct specialty's information by specialty's id
        /// </summary>
        /// <param name="specialty"></param>
        /// <returns>Success or not</returns>
        [HttpPut]
        public ActionResult<SpecialtyDto> Put([FromBody] SpecialtyDto specialty)
        {
            _logger.LogInformation($"Updating specialty with ID: {specialty.SpecialtyId}.");
            if (!_service.Put(specialty))
            {
                _logger.LogWarning($"Specialty with ID {specialty.SpecialtyId} not found for update.");
                return NotFound();
            }

            _logger.LogInformation($"Specialty with ID {specialty.SpecialtyId} was successfully updated.");
            return Ok(specialty);
        }

        /// <summary>
        /// Delete specialty by specialty's id
        /// </summary>
        /// <param name="SpecialtyId">Specialty's id</param>
        /// <returns>Success or not</returns>
        [HttpDelete("{SpecialtyId}")]
        public ActionResult<string> Delete(string SpecialtyId)
        {
            _logger.LogInformation($"Attempting to delete specialty with ID: {SpecialtyId}.");
            if (!_service.Delete(SpecialtyId))
            {
                _logger.LogWarning($"Specialty with ID {SpecialtyId} not found for deletion.");
                return NotFound();
            }

            _logger.LogInformation($"Specialty with ID {SpecialtyId} was successfully deleted.");
            return Ok("Specialty was deleted");
        }
    }
}
