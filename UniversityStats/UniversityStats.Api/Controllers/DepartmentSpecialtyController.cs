using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;  // Для логирования
using UniversityStats.API.Dto;
using UniversityStats.API.Services;

namespace UniversityStats.API.Controllers
{
    /// <summary>
    /// Class for (department specialty)'s controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentSpecialtyController : ControllerBase
    {
        private readonly DepartmentSpecialtyService _service;
        private readonly ILogger<DepartmentSpecialtyController> _logger;  // Логер для контроллера

        // Конструктор с внедрением зависимостей
        public DepartmentSpecialtyController(DepartmentSpecialtyService service, ILogger<DepartmentSpecialtyController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Return list of (department specialty)
        /// </summary>
        /// <returns> List of (department specialty)</returns>
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentSpecialtyDto>> Get()
        {
            _logger.LogInformation("Fetching list of all department specialties.");  // Логируем начало операции
            var departmentSpecialties = _service.GetAll();

            if (departmentSpecialties == null || !departmentSpecialties.Any())
            {
                _logger.LogWarning("No department specialties found.");  // Логируем предупреждение, если не найдены данные
                return NotFound("No department specialties found.");
            }

            _logger.LogInformation("Successfully fetched all department specialties.");  // Логируем успешное выполнение
            return Ok(departmentSpecialties);
        }

        /// <summary>
        /// Find (department specialty)'s information by specialty's id
        /// </summary>
        /// <param name="specialtyId">Specialty's id</param>
        /// <returns>(department specialty)'s information</returns>
        [HttpGet("{specialtyId}")]
        public ActionResult<DepartmentSpecialtyDto> Get(string specialtyId)
        {
            _logger.LogInformation($"Fetching department specialty with id: {specialtyId}.");  // Логируем начало операции
            var departmentSpecialty = _service.GetById(specialtyId);

            if (departmentSpecialty == null)
            {
                _logger.LogWarning($"Department specialty with id: {specialtyId} not found.");  // Логируем, если не найдено
                return NotFound();
            }

            _logger.LogInformation($"Successfully fetched department specialty with id: {specialtyId}.");  // Логируем успех
            return Ok(departmentSpecialty);
        }

        /// <summary>
        /// Add (department specialty) to database
        /// </summary>
        /// <param name="departmentSpecialty">(Department specialty)'s information in format DTO</param>
        /// <returns>Success or not</returns>
        [HttpPost]
        public ActionResult<DepartmentSpecialtyDto> Post([FromBody] DepartmentSpecialtyDto departmentSpecialty)
        {
            _logger.LogInformation("Adding new department specialty to the database.");
            _service.Post(departmentSpecialty);

            _logger.LogInformation("Department specialty added successfully.");
            return Ok(departmentSpecialty);
        }

        /// <summary>
        /// Correct (department specialty)'s information by specialty's id
        /// </summary>
        /// <param name="departmentSpecialty">(Department specialty)'s information</param>
        /// <returns>Success or not</returns>
        [HttpPut]
        public ActionResult<DepartmentSpecialtyDto> Put([FromBody] DepartmentSpecialtyDto departmentSpecialty)
        {
            _logger.LogInformation($"Updating department specialty with id: {departmentSpecialty.SpecialtyId}");  // Исправляем на правильное свойство

            if (!_service.Put(departmentSpecialty))
            {
                _logger.LogWarning($"Department specialty with id: {departmentSpecialty.SpecialtyId} not found for update.");  // Исправляем на правильное свойство
                return NotFound();
            }

            _logger.LogInformation($"Successfully updated department specialty with id: {departmentSpecialty.SpecialtyId}.");  // Исправляем на правильное свойство
            return Ok(departmentSpecialty);
        }

        /// <summary>
        /// Delete (department specialty) by specialty's id
        /// </summary>
        /// <param name="specialtyId">Specialty's id</param>
        /// <returns>Success or not</returns>
        [HttpDelete("{specialtyId}")]
        public ActionResult<string> Delete(string specialtyId)
        {
            _logger.LogInformation($"Deleting department specialty with id: {specialtyId}");

            if (!_service.Delete(specialtyId))
            {
                _logger.LogWarning($"Department specialty with id: {specialtyId} not found for deletion.");
                return NotFound();
            }

            _logger.LogInformation($"Successfully deleted department specialty with id: {specialtyId}");
            return Ok("Department specialty was deleted");
        }
    }
}
