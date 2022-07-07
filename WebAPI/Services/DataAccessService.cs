using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class DataAccessService
    {
        private const string CONN_STRING = @"Server=(localdb)\mssqllocaldb;Database=LinqSQLPractices;Trusted_Connection=True;";

        // TODO : Question 1 - Write a SQL Query to fetch all the duplicate records in a table.
        public UserResultDTO FetchAllTheDuplicateRecords()
        {

            IDbConnection conn = new SqlConnection(CONN_STRING);

            var result = conn.Query<Users>("GetAllUsers", commandType: CommandType.StoredProcedure);

            if (result.Any())
            {
                IEnumerable<Users> listUsers = result;

                var groupList = (from users in result
                                 group users by new
                                 {
                                     users.User_Name,
                                     users.Email
                                 } into gu
                                 select new
                                 {
                                     User_Id = listUsers.Last(x => x.User_Name.Equals(gu.Key.User_Name)).User_Id,
                                     Email = gu.Key.Email,
                                     User_Name = gu.Key.User_Name,
                                     IsDuplicate = gu.Count() > 1
                                 }).ToList();

                var linqQuery = groupList.Where(x => x.IsDuplicate == true)
                    .Select(x => new Users
                    {
                        User_Id = x.User_Id,
                        Email = x.Email,
                        User_Name = x.User_Name
                    }).ToList();

                var rawSQL = conn.Query<Users>("GetDuplicateRecord", commandType: CommandType.StoredProcedure);

                conn.Close();

                return new UserResultDTO
                {
                    LINQResult = linqQuery,
                    SQLResult = rawSQL
                };
            }
            return null;
        }

        // TODO : Question 2 - Write a SQL query to fetch the second last record from employee table.
        public EmployeeResultDTO FetchTheSecondLastRecordFromEmployee()
        {
            IDbConnection conn = new SqlConnection(CONN_STRING);

            var result = conn.Query<Employees>("GetAllEmployees", commandType: CommandType.StoredProcedure);

            if (result.Any())
            {
                var linqQuery = (from employee in result
                                 orderby employee.Emp_Id descending
                                 select new Employees
                                 {
                                     Emp_Id = employee.Emp_Id,
                                     Emp_Name = employee.Emp_Name,
                                     Dept_Name = employee.Dept_Name,
                                     Salary = employee.Salary
                                 })
                                 .Take(2)
                                 .Skip(1)
                                 .FirstOrDefault();

                var rawSQL = conn.QueryFirst<Employees>("GetSecondLastRecord", commandType: CommandType.StoredProcedure);

                return new EmployeeResultDTO
                {
                    LINQResult = linqQuery,
                    SQLResult = rawSQL
                };
            }
            return null;
        }

        // TODO : Question 3 - Write a SQL query to display only the details of employees who either earn the highest salary or the lowest salary in each department from the employee table.
        public EmployeeeHighestLowestSalaryResultDTO HighestAndLowestSalaryByDepartment()
        {
            IDbConnection conn = new SqlConnection(CONN_STRING);

            var result = conn.Query<Employees>("GetAllEmployees", commandType: CommandType.StoredProcedure);

            if (result.Any())
            {
                var listMaxAndMinSalary = result.Select(x => new EmployeeeHighestLowestSalaryDTO
                {
                    Emp_Id = x.Emp_Id,
                    Emp_Name = x.Emp_Name,
                    Dept_Name = x.Dept_Name,
                    Salary = x.Salary,
                    Max_Salary = result.Where(y => y.Dept_Name == x.Dept_Name).Max(y => y.Salary),
                    Min_Salary = result.Where(y => y.Dept_Name == x.Dept_Name).Min(y => y.Salary),
                }).OrderBy(s => s.Dept_Name).ThenBy(s => s.Salary).ToList();

                var linqQuery = (from e in result
                                 join s in listMaxAndMinSalary
                                 on e.Emp_Id equals s.Emp_Id
                                 where e.Salary.ToString().Equals(s.Max_Salary.ToString()) ||
                                        e.Salary.ToString().Equals(s.Min_Salary.ToString())
                                 select new EmployeeeHighestLowestSalaryDTO
                                 {
                                     Emp_Id = s.Emp_Id,
                                     Emp_Name = s.Emp_Name,
                                     Dept_Name = s.Dept_Name,
                                     Salary = s.Salary,
                                     Max_Salary = s.Max_Salary,
                                     Min_Salary = s.Min_Salary
                                 }).OrderBy(x => x.Emp_Name).ToList();

                var rawSql = conn.Query<EmployeeeHighestLowestSalaryDTO>("[dbo].[GetHighestAndLowestSalary]", commandType: CommandType.StoredProcedure);

                return new EmployeeeHighestLowestSalaryResultDTO
                {
                    LINQResult = linqQuery,
                    SQLResult = rawSql.OrderBy(x => x.Emp_Name),
                    IsMatch = linqQuery.Select(x => x.Emp_Id)
                    .SequenceEqual(rawSql.OrderBy(x => x.Emp_Name).Select(y => y.Emp_Id))
                };
            }

            return null;
        }

        // TODO : Question 4 - From the doctors table, fetch the details of doctors who work in the same hospital but in different specialty.
        public DoctorWithSameHospitalOrIrrespectiveSpecialityDTO DoctorWithSameHospitalOrIrrespectiveSpeciality()
        {
            IDbConnection conn = new SqlConnection(CONN_STRING);

            var result = conn.Query<Doctors>("GetAllDoctors", commandType: CommandType.StoredProcedure);

            if (result.Any())
            {


                var linqSameHospital = result.Select(x => new DoctorWithSameHospitalDTO
                {
                    Name = x.Name,
                    Hospital = x.Hospital,
                    Speciality = x.Speciality
                });

                linqSameHospital = (from a in linqSameHospital
                                    join b in result
                                    on a.Hospital equals b.Hospital
                                    where a.Speciality != b.Speciality
                                    select a).ToList();


                var linqIrrespectiveSpecialityDTO = (from a in result
                                                     from b in result
                                                     where a.Hospital == b.Hospital
                                                     && a.Id != b.Id
                                                     select new DoctorWithIrrespectiveSpecialityDTO
                                                     {
                                                         Name = a.Name,
                                                         Hospital = a.Hospital,
                                                         Speciality = a.Speciality
                                                     }).ToList();

                var rawSqlSameHospital = conn.Query<DoctorWithSameHospitalDTO>("GetDoctorSpeciality ",
                                                    new { param1 = "SameHospitalDifferentSpeciality" },
                                                    commandType: CommandType.StoredProcedure);

                var rawSqlIrrespectiveSpeciality = conn.Query<DoctorWithIrrespectiveSpecialityDTO>("GetDoctorSpeciality",
                                                    new { param1 = "SameHospitalIrrespectiveSpeciality" },
                                                    commandType: CommandType.StoredProcedure);

                return new DoctorWithSameHospitalOrIrrespectiveSpecialityDTO
                {
                    LINQResultIrrespectiveSpeciality = linqIrrespectiveSpecialityDTO,
                    LINQResultSameHospital = linqSameHospital,
                    SQLResultIrrespectiveSpeciality = rawSqlIrrespectiveSpeciality,
                    SQLResultSameHospital = rawSqlSameHospital
                };
            }

            return null;
        }

        // TODO : Question 5 - rom the login_details table, fetch the users who logged in consecutively 3 or more times.
        public LoginDetailsDTO UserLoginMoreThen3Times()
        {
            IDbConnection conn = new SqlConnection(CONN_STRING);

            var result = conn.Query<Login_Details>("GetAllLoginDetails", commandType: CommandType.StoredProcedure);

            if (result.Any())
            {

                var linqGroupBy = (from login in result
                                   group login by login.User_Name into g
                                   select new
                                   {
                                       repeated_names = g.Key,
                                       count = g.Count()
                                   }).ToList();

                var linqResult = linqGroupBy.Where(x => x.count > 3)
                    .Select(x => new RepeatedNamesDTO
                    {
                        Repeated_Names = x.repeated_names
                    }).ToList();

                var rawSQL = conn.Query<RepeatedNamesDTO>("GetUserLoginMoreThen3Times",
                                                           new { param = "LeadMethod" },
                                                           commandType: CommandType.StoredProcedure);

                return new LoginDetailsDTO
                {
                    LINQResult = linqResult,
                    SQLResult = rawSQL
                };
            }

            return null;
        }
    }
}
