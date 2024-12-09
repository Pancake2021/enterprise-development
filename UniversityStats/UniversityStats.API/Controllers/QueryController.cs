using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;  // Для логирования
using UniversityStats.API.Dto;
using UniversityStats.API.Services;

namespace UniversityStats.API.Controllers
{
    /// <summary>
    /// Class for Query's controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController(
        QueryService service, 
        ILogger<QueryController> logger) : ControllerBase
    {
        private readonly QueryService _service;
        private readonly ILogger<QueryController> _logger;  // Логер для контроллера

        // Внедрение зависимостей через конструктор
        public QueryController(QueryService service, ILogger<QueryController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Return list of university's information with registration number
        /// </summary>
        /// <param name="registrationNumber">Registration number</param>
        /// <returns>University's information with registration number</returns>
        [HttpGet("Universities")]
        public ActionResult<UniversityDto> InfoUniversityByRegistration(string registrationNumber)
        {
            _logger.LogInformation($"Fetching university info for registration number: {registrationNumber}.");
            var university = _service.InfoUniversityByRegistration(registrationNumber);

            if (university == null)
            {
                _logger.LogWarning($"University with registration number {registrationNumber} not found.");
                return NoContent();
            }

            _logger.LogInformation($"Successfully fetched university info for registration number: {registrationNumber}.");
            return Ok(university);
        }

        /// <summary>
        /// Count total departments in every university
        /// </summary>
        /// <returns>List of objects mentioned in format json</returns>
        [HttpGet("Departments")]
        public ActionResult<UniversityAndDepartmentsDto> TotalDepartmentsInUniversity()
        {
            _logger.LogInformation("Fetching total number of departments in universities.");
            var departments = _service.TotalDepartmentsInUniversity();

            if (departments == null)
            {
                _logger.LogWarning("No departments found.");
                return NoContent();
            }

            _logger.LogInformation("Successfully fetched total departments in universities.");
            return Ok(departments);
        }

        /// <summary>
        /// Find 5 specialties with the highest number of groups
        /// </summary>
        /// <returns>List of objects mentioned in format json</returns>
        [HttpGet("Top5Specialties")]
        public ActionResult<SpecialtyAndGroupsDto> TopFiveSpecialties()
        {
            _logger.LogInformation("Fetching top 5 specialties with highest number of groups.");
            var specialties = _service.TopFiveSpecialties();

            if (specialties == null)
            {
                _logger.LogWarning("No specialties found.");
                return NoContent();
            }

            _logger.LogInformation("Successfully fetched top 5 specialties.");
            return Ok(specialties);
        }

        /// <summary>
        /// Count total of groups with property type
        /// </summary>
        /// <param name="propertyType">Property type</param>
        /// <returns>List of objects mentioned in format json</returns>
        [HttpGet("Properties")]
        public ActionResult<PropertyAndGroupsDto> TotalGroupsByProperty(string propertyType)
        {
            _logger.LogInformation($"Fetching total groups by property type: {propertyType}.");
            var groups = _service.TotalGroupsByProperty(propertyType);

            if (groups == null)
            {
                _logger.LogWarning($"No groups found for property type: {propertyType}.");
                return NoContent();
            }

            _logger.LogInformation($"Successfully fetched total groups for property type: {propertyType}.");
            return Ok(groups);
        }

        /// <summary>
        /// Return list of faculties and specialties available in university
        /// </summary>
        /// <param name="nameUniversity">University's name</param>
        /// <returns>List of objects mentioned in format json</returns>
        [HttpGet("FacultiesSpecialties")]
        public ActionResult<FacultyAndSpecialtyDto> InfoFacultiesSpecialties(string nameUniversity)
        {
            _logger.LogInformation($"Fetching faculties and specialties for university: {nameUniversity}.");
            var facultiesSpecialties = _service.InfoFacultiesSpecialties(nameUniversity);

            if (facultiesSpecialties == null)
            {
                _logger.LogWarning($"No faculties or specialties found for university: {nameUniversity}.");
                return NoContent();
            }

            _logger.LogInformation($"Successfully fetched faculties and specialties for university: {nameUniversity}.");
            return Ok(facultiesSpecialties);
        }

        /// <summary>
        /// Count total of departments, faculties and specialties by attributes property type and building owner
        /// </summary>
        /// <returns>List of objects mentioned in format json</returns>
        [HttpGet("PropertiesBuildings")]
        public ActionResult<PropertyAndBuildingDto> TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding()
        {
            _logger.LogInformation("Fetching total departments, faculties, and specialties by property type and building owner.");
            var data = _service.TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding();

            if (data == null)
            {
                _logger.LogWarning("No data found for properties and buildings.");
                return NoContent();
            }

            _logger.LogInformation("Successfully fetched total departments, faculties, and specialties by property type and building owner.");
            return Ok(data);
        }
    }
}
