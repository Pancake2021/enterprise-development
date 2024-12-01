using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;  // Для логирования
using UniversityStats.API.Dto;
using UniversityStats.API.Services;

namespace UniversityStats.API.Controllers
{
    /// <summary>
    /// Class for university's controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly UniversityService _service;
        private readonly ILogger<UniversityController> _logger;  // Логер для контроллера

        // Внедрение зависимостей через конструктор
        public UniversityController(UniversityService service, ILogger<UniversityController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Return list of universities
        /// </summary>
        /// <returns> List of universities</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UniversityDto>> Get()
        {
            _logger.LogInformation("Fetching list of universities.");
            var universities = _service.GetAll();

            if (universities == null || !universities.Any())
            {
                _logger.LogWarning("No universities found.");
                return NotFound();
            }

            _logger.LogInformation("Successfully fetched list of universities.");
            return Ok(universities);
        }

        /// <summary>
        /// Return university's information by registration number
        /// </summary>
        /// <param name="registrationNumber">University's registration number</param>
        /// <returns>University's information</returns>
        [HttpGet("{registrationNumber}")]
        public ActionResult<UniversityDto> Get(string registrationNumber)
        {
            _logger.LogInformation($"Fetching university information for registration number: {registrationNumber}.");
            var university = _service.GetById(registrationNumber);

            if (university == null)
            {
                _logger.LogWarning($"University with registration number {registrationNumber} not found.");
                return NotFound();
            }

            _logger.LogInformation($"Successfully fetched university with registration number: {registrationNumber}.");
            return Ok(university);
        }

        /// <summary>
        /// Post university's information to database
        /// </summary>
        /// <param name="university">University's information</param>
        /// <returns>Success or not</returns>
        [HttpPost]
        public ActionResult<UniversityDto> Post([FromBody] UniversityDto university)
        {
            _logger.LogInformation("Posting new university information.");
            _service.Post(university);

            _logger.LogInformation($"University with registration number {university.RegistrationNumber} was successfully posted.");
            return Ok(university);
        }

        /// <summary>
        /// Correct university's information by id
        /// </summary>
        /// <param name="university">University's information</param>
        /// <returns>Success or not</returns>
        [HttpPut]
        public ActionResult<UniversityDto> Put([FromBody] UniversityDto university)
        {
            _logger.LogInformation($"Updating university with registration number: {university.RegistrationNumber}.");
            if (!_service.Put(university))
            {
                _logger.LogWarning($"University with registration number {university.RegistrationNumber} not found for update.");
                return NotFound();
            }

            _logger.LogInformation($"University with registration number {university.RegistrationNumber} was successfully updated.");
            return Ok(university);
        }

        /// <summary>
        /// Delete university's information by registration number
        /// </summary>
        /// <param name="registrationNumber">Registration number</param>
        /// <returns>Success or not</returns>
        [HttpDelete("{registrationNumber}")]
        public ActionResult<string> Delete(string registrationNumber)
        {
            _logger.LogInformation($"Attempting to delete university with registration number: {registrationNumber}.");
            if (!_service.Delete(registrationNumber))
            {
                _logger.LogWarning($"University with registration number {registrationNumber} not found for deletion.");
                return NotFound();
            }

            _logger.LogInformation($"University with registration number {registrationNumber} was successfully deleted.");
            return Ok("University was deleted");
        }
    }
}
