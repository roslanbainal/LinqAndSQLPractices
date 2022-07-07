using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly DataAccessService _dataAccessService;

        public ResultController(DataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        [HttpGet("FetchAllTheDuplicateRecords")]
        public IActionResult FetchAllTheDuplicateRecords()
        {
            return Ok(_dataAccessService.FetchAllTheDuplicateRecords());
        }

        [HttpGet("FetchTheSecondLastRecordFromEmployee")]
        public IActionResult FetchTheSecondLastRecordFromEmployee()
        {
            return Ok(_dataAccessService.FetchTheSecondLastRecordFromEmployee());
        }

        [HttpGet("HighestAndLowestSalaryByDepartment")]
        public IActionResult HighestAndLowestSalaryByDepartment()
        {
            return Ok(_dataAccessService.HighestAndLowestSalaryByDepartment());
        }

        [HttpGet("DoctorWithSameHospitalOrIrrespectiveSpeciality")]
        public IActionResult DoctorWithSameHospitalOrIrrespectiveSpeciality()
        {
            return Ok(_dataAccessService.DoctorWithSameHospitalOrIrrespectiveSpeciality());
        }

        [HttpGet("UserLoginMoreThen3Times")]
        public IActionResult UserLoginMoreThen3Times()
        {
            return Ok(_dataAccessService.UserLoginMoreThen3Times());
        }

    }
}
