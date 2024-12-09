using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityStats.API.Services;
using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.API.Controllers
{
    /// <summary>
    /// Class for university's controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController(
        UniversityService service, 
        ILogger<UniversityController> logger) : ControllerBase
    {
        private readonly UniversityService _service;
        private readonly ILogger<UniversityController> _logger;

        public UniversityController(
            UniversityService service, 
            ILogger<UniversityController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Return list of universities
        /// </summary>
        /// <returns>List of universities</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetAll()
        {
            _logger.LogInformation("Fetching list of universities.");
            var universities = await _service.GetAllUniversitiesAsync();

            if (!universities.Any())
            {
                _logger.LogWarning("No universities found.");
                return NoContent();
            }

            _logger.LogInformation("Successfully fetched list of universities.");
            return Ok(universities);
        }

        /// <summary>
        /// Return university's information by id
        /// </summary>
        /// <param name="id">University's id</param>
        /// <returns>University's information</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetById(int id)
        {
            _logger.LogInformation($"Fetching university information for id: {id}.");
            var university = await _service.GetUniversityByIdAsync(id);

            if (university == null)
            {
                _logger.LogWarning($"University with id {id} not found.");
                return NoContent();
            }

            _logger.LogInformation($"Successfully fetched university with id: {id}.");
            return Ok(university);
        }

        /// <summary>
        /// Post university's information to database
        /// </summary>
        /// <param name="university">University's information</param>
        /// <returns>Created university</returns>
        [HttpPost]
        public async Task<ActionResult<University>> Create([FromBody] University university)
        {
            _logger.LogInformation("Creating new university.");
            var createdUniversity = await _service.CreateUniversityAsync(university);

            _logger.LogInformation($"University with id {createdUniversity.Id} was successfully created.");
            return CreatedAtAction(nameof(GetById), new { id = createdUniversity.Id }, createdUniversity);
        }

        /// <summary>
        /// Update university's information
        /// </summary>
        /// <param name="id">University's id</param>
        /// <param name="university">University's information</param>
        /// <returns>Updated university</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<University>> Update(int id, [FromBody] University university)
        {
            if (id != university.Id)
            {
                _logger.LogWarning("Id in URL does not match id in body.");
                return BadRequest();
            }

            _logger.LogInformation($"Updating university with id: {id}.");
            var updatedUniversity = await _service.UpdateUniversityAsync(university);

            if (updatedUniversity == null)
            {
                _logger.LogWarning($"University with id {id} not found for update.");
                return NoContent();
            }

            _logger.LogInformation($"University with id {id} was successfully updated.");
            return Ok(updatedUniversity);
        }

        /// <summary>
        /// Delete university's information
        /// </summary>
        /// <param name="id">University's id</param>
        /// <returns>Success or not</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation($"Attempting to delete university with id: {id}.");
            var result = await _service.DeleteUniversityAsync(id);

            if (!result)
            {
                _logger.LogWarning($"University with id {id} not found for deletion.");
                return NoContent();
            }

            _logger.LogInformation($"University with id {id} was successfully deleted.");
            return NoContent();
        }
    }
}
