using WebAPI.Models;

namespace WebAPI.Dto
{
    #region UserDTO
    public class UserResultDTO
    {
        public IEnumerable<Users> LINQResult { get; set; }
        public IEnumerable<Users> SQLResult { get; set; }
    }
    #endregion

    #region EmployeeDTO
    public class EmployeeResultDTO
    {
        public Employees LINQResult { get; set; }
        public Employees SQLResult { get; set; }
    }

    public class EmployeeeHighestLowestSalaryResultDTO
    {
        public IEnumerable<EmployeeeHighestLowestSalaryDTO> LINQResult { get; set; }
        public IEnumerable<EmployeeeHighestLowestSalaryDTO> SQLResult { get; set; }
        public bool IsMatch { get; set; }
    }

    public class EmployeeeHighestLowestSalaryDTO
    {
        public int Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        public string Dept_Name { get; set; }
        public int Salary { get; set; }
        public int Max_Salary { get; set; }
        public int Min_Salary { get; set; }
    }
    #endregion

    #region DoctorDTO
    public class DoctorDTO 
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Hospital { get; set; }
    }

    public class DoctorWithSameHospitalDTO : DoctorDTO { }
    public class DoctorWithIrrespectiveSpecialityDTO : DoctorDTO { }

    public class DoctorWithSameHospitalOrIrrespectiveSpecialityDTO
    {
        public IEnumerable<DoctorWithSameHospitalDTO> LINQResultSameHospital { get; set; }
        public IEnumerable<DoctorWithIrrespectiveSpecialityDTO> LINQResultIrrespectiveSpeciality { get; set; }

        public IEnumerable<DoctorWithSameHospitalDTO> SQLResultSameHospital { get; set; }
        public IEnumerable<DoctorWithIrrespectiveSpecialityDTO> SQLResultIrrespectiveSpeciality { get; set; }

    }
    #endregion

    #region LoginDTO
    public class RepeatedNamesDTO
    {
        public string Repeated_Names { get; set; }
    }

    public class LoginDetailsDTO
    {
        public IEnumerable<RepeatedNamesDTO> LINQResult { get; set; }
        public IEnumerable<RepeatedNamesDTO> SQLResult { get; set; }
    }
    #endregion

    #region StudentDTO
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Student_Name { get; set; }
        public string New_Student_Name { get; set; }
    }

    public class StudentInterchangeAdjacentStudentNamesDTO
    {
        public IEnumerable<StudentDTO> LINQResult { get; set; }
        public IEnumerable<StudentDTO> SQLResult { get; set; }
    }

    #endregion
}
