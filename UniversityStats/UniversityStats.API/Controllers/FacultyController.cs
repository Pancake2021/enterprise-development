using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;  // Для логирования
using UniversityStats.API.Dto;
using UniversityStats.API.Services;

namespace UniversityStats.API.Controllers
{
    /// <summary>
    /// Class for Faculty's controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly FacultyService _service;
        private readonly ILogger<FacultyController> _logger;  // Логер для контроллера

        // Конструктор с внедрением зависимостей
        public FacultyController(FacultyService service, ILogger<FacultyController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Return list of faculties
        /// </summary>
        /// <returns>List of faculties</returns>
        [HttpGet]
        public ActionResult<IEnumerable<FacultyDto>> Get()
        {
            _logger.LogInformation("Fetching list of all faculties.");  // Логируем начало операции
            var faculties = _service.GetAll();

            if (faculties == null || !faculties.Any())
            {
                _logger.LogWarning("No faculties found.");  // Логируем предупреждение, если не найдены данные
                return NotFound("No faculties found.");
            }

            _logger.LogInformation("Successfully fetched all faculties.");  // Логируем успешное выполнение
            return Ok(faculties);
        }

        /// <summary>
        /// Find faculty's information by faculty's id
        /// </summary>
        /// <param name="facultyId">Faculty's id</param>
        /// <returns>Faculty's information</returns>
        [HttpGet("{facultyId}")]
        public ActionResult<FacultyDto> Get(string facultyId)
        {
            _logger.LogInformation($"Fetching faculty with id: {facultyId}.");  // Логируем начало операции
            var faculty = _service.GetById(facultyId);

            if (faculty == null)
            {
                _logger.LogWarning($"Faculty with id: {facultyId} not found.");  // Логируем, если не найдено
                return NotFound();
            }

            _logger.LogInformation($"Successfully fetched faculty with id: {facultyId}.");  // Логируем успех
            return Ok(faculty);
        }

        /// <summary>
        /// Post faculty's information to database
        /// </summary>
        /// <param name="faculty">Faculty's information</param>
        /// <returns>Success or not</returns>
        [HttpPost]
        public ActionResult<FacultyDto> Post([FromBody] FacultyDto faculty)
        {
            _logger.LogInformation("Adding new faculty to the database.");
            _service.Post(faculty);

            _logger.LogInformation("Faculty added successfully.");
            return Ok(faculty);
        }

        /// <summary>
        /// Correct faculty's information by faculty's id
        /// </summary>
        /// <param name="faculty">Faculty's information</param>
        /// <returns>Success or not</returns>
        [HttpPut]
        public ActionResult<FacultyDto> Put([FromBody] FacultyDto faculty)
        {
            _logger.LogInformation($"Updating faculty with id: {faculty.FacultyId}");  // Исправляем на правильное свойство

            if (!_service.Put(faculty))
            {
                _logger.LogWarning($"Faculty with id: {faculty.FacultyId} not found for update.");  // Логируем, если не найдено
                return NotFound();
            }

            _logger.LogInformation($"Successfully updated faculty with id: {faculty.FacultyId}.");  // Логируем успех
            return Ok(faculty);
        }

        /// <summary>
        /// Delete faculty by faculty's id
        /// </summary>
        /// <param name="facultyId">Faculty's id</param>
        /// <returns>Success or not</returns>
        [HttpDelete("{facultyId}")]
        public ActionResult<string> Delete(string facultyId)
        {
            _logger.LogInformation($"Deleting faculty with id: {facultyId}");

            if (!_service.Delete(facultyId))
            {
                _logger.LogWarning($"Faculty with id: {facultyId} not found for deletion.");
                return NotFound();
            }

            _logger.LogInformation($"Successfully deleted faculty with id: {facultyId}");
            return Ok("Faculty was deleted");
        }
    }
}
