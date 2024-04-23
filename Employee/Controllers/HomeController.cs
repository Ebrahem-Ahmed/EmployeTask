using Employee.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region IndexView
        public IActionResult Index()
        {
            //PopulateDropDownLists();
            var employees = GetEmployees();
            return View(employees);
        }
        #endregion




        #region GetAllEmlpyees
        public List<Employees> GetEmployees()
        {
            string x = "";
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Employees.txt");
                string[] lines = System.IO.File.ReadAllLines(filePath);

                List<Employees> employees = new List<Employees>();
                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    x = parts[2];
                    Employees emp = new Employees
                    {
                        Name = parts[0],
                        Address = parts[1].Replace('"', ' '),
                        BirthDate = parts[2] == null || parts[2] == "" ? DateTime.Parse("1900-01-01") : DateParse(parts[2]),
                        Graduation = parts[3],
                        EmploymentType = parts[4],

                    };


                    if (double.TryParse(parts[5], out double salary))
                    {
                        emp.Salary = salary;
                    }
                    else
                    {

                        emp.Salary = 0;
                    }

                    if (emp.EmploymentType != "Freelancer")
                    {
                        try
                        {
                            emp.Assurance = parts[6];
                        }
                        catch
                        {
                            emp.Assurance = "";
                        }
                    }

                    employees.Add(emp);
                }

                return employees;
            }
            catch (Exception ex)
            {


                _logger.LogError($"Error getting employees: {ex.Message}");
                return new List<Employees>();
            }
        }

        #endregion

        #region GetemployeMonthlyparoll
        public List<Employees> GetEmployeesMonthlypayroll()
        {
            string x = "";
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Employees.txt");
                string[] lines = System.IO.File.ReadAllLines(filePath);

                List<Employees> employees = new List<Employees>();
                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 7 && parts[4] == "Monthly payroll")
                    {
                        x = parts[2];
                        Employees emp = new Employees
                        {
                            Name = parts[0],
                            Address = parts[1].Replace('"', ' '),
                            BirthDate = parts[2] == null || parts[2] == "" ? DateTime.Parse("1900-01-01") : DateParse(parts[2]),
                            Graduation = parts[3],
                            EmploymentType = parts[4],
                            // Salary = double.Parse(parts[5])
                        };
                        if (double.TryParse(parts[5], out double salary))
                        {
                            emp.Salary = salary;
                        }
                        else
                        {

                            emp.Salary = 0;
                        }
                        if (emp.EmploymentType != "Freelancer")
                        {
                            try
                            {
                                emp.Assurance = parts[6];
                            }
                            catch
                            {
                                emp.Assurance = "";
                            }
                        }
                        employees.Add(emp);
                    }







                }

                return employees;
            }
            catch (Exception ex)
            {


                _logger.LogError($"Error getting employees: {ex.Message}");
                return new List<Employees>();
            }
        }

        #endregion

        #region GetEmployeesFreelancer
        public List<Employees> GetEmployeesFreelancer()
        {
            string x = "";
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Employees.txt");
                string[] lines = System.IO.File.ReadAllLines(filePath);

                List<Employees> employees = new List<Employees>();
                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 7 && parts[4] == "Free lancer")
                    {
                        x = parts[2];
                        Employees emp = new Employees
                        {
                            Name = parts[0],
                            Address = parts[1].Replace('"', ' '),
                            BirthDate = parts[2] == null || parts[2] == "" ? DateTime.Parse("1900-01-01") : DateParse(parts[2]),
                            Graduation = parts[3],
                            EmploymentType = parts[4],
                            // Salary = double.Parse(parts[5])
                        };
                        if (double.TryParse(parts[5], out double salary))
                        {
                            emp.Salary = salary;
                        }
                        else
                        {

                            emp.Salary = 0;
                        }
                        if (emp.EmploymentType != "Freelancer")
                        {
                            try
                            {
                                emp.Assurance = parts[6];
                            }
                            catch
                            {
                                emp.Assurance = "";
                            }
                        }
                        employees.Add(emp);
                    }







                }

                return employees;
            }
            catch (Exception ex)
            {

                // Handle exceptions
                _logger.LogError($"Error getting employees: {ex.Message}");
                return new List<Employees>();
            }
        }

        #endregion

        #region GetEmployeesHourlyPayroll
        public List<Employees> GetEmployeesHourlyPayroll()
        {
            string x = "";
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Employees.txt");
                string[] lines = System.IO.File.ReadAllLines(filePath);

                List<Employees> employees = new List<Employees>();
                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 7 && parts[4] == "Hourly Payroll")
                    {
                        x = parts[2];
                        Employees emp = new Employees
                        {
                            Name = parts[0],
                            Address = parts[1].Replace('"', ' '),
                            BirthDate = parts[2] == null || parts[2] == "" ? DateTime.Parse("1900-01-01") : DateParse(parts[2]),
                            Graduation = parts[3],
                            EmploymentType = parts[4],
                            // Salary = double.Parse(parts[5])
                        };
                        if (double.TryParse(parts[5], out double salary))
                        {
                            emp.Salary = salary;
                        }
                        else
                        {

                            emp.Salary = 0;
                        }
                        if (emp.EmploymentType != "Freelancer")
                        {
                            try
                            {
                                emp.Assurance = parts[6];
                            }
                            catch
                            {
                                emp.Assurance = "";
                            }
                        }
                        employees.Add(emp);
                    }







                }

                return employees;
            }
            catch (Exception ex)
            {


                _logger.LogError($"Error getting employees: {ex.Message}");
                return new List<Employees>();
            }
        }

        #endregion

        #region AddNewEmployee
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employees newEmployee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Employees.txt");

                    string newLine = $"{newEmployee.Name}\t{newEmployee.Address}\t{newEmployee.BirthDate.ToString("dd/MM/yyyy")}\t{newEmployee.Graduation}\t{newEmployee.EmploymentType}\t{newEmployee.Salary}";

                    System.IO.File.AppendAllText(filePath, newLine + Environment.NewLine);
                    TempData["Success"] = "Employee added successfully.";
                    return RedirectToAction("Index");
                }
                return View(newEmployee);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error adding employee: {ex.Message}");
                return View(newEmployee);
            }
        }

        #endregion

        #region EditEmployee
        [HttpGet]
        public IActionResult EditEmployee(string name)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Employees.txt");
                string[] lines = System.IO.File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    if (parts[0] == name)
                    {
                        Employees emp = new Employees
                        {
                            Name = parts[0],
                            Address = parts[1],
                            BirthDate = parts[2] == null || parts[2] == "" ? DateTime.Parse("1900-01-01") : DateParse(parts[2]),

                            Graduation = parts[3],
                            EmploymentType = parts[4],

                        };
                        if (double.TryParse(parts[5], out double salary))
                        {
                            emp.Salary = salary;
                        }
                        else
                        {

                            emp.Salary = 0;
                        }

                        if (emp.EmploymentType != "Freelancer")
                        {
                            try
                            {
                                emp.Assurance = parts[6];
                            }
                            catch
                            {
                                emp.Assurance = "";
                            }
                        }
                        return View(emp);
                    }
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error editing employee: {ex.Message}");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditEmployee(string name, Employees updatedEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Employees.txt");
                    List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string[] parts = lines[i].Split('\t');
                        if (parts[0] == name)
                        {
                            lines[i] = $"{updatedEmployee.Name}\t{updatedEmployee.Address}\t{updatedEmployee.BirthDate.ToString("dd/MM/yyyy")}\t{updatedEmployee.Graduation}\t{updatedEmployee.EmploymentType}\t{updatedEmployee.Salary}";
                            System.IO.File.WriteAllLines(filePath, lines);
                            return RedirectToAction("Index");
                        }
                    }
                    return NotFound();
                }
                return View(updatedEmployee);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error editing employee: {ex.Message}");
                return View(updatedEmployee);
            }
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult DeleteEmployee(string name)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Employees.txt");
                List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();

                bool employeeFound = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Split('\t');
                    if (parts[0] == name)
                    {
                        lines.RemoveAt(i);
                        employeeFound = true;
                        break;
                    }
                }

                if (employeeFound)
                {
                    System.IO.File.WriteAllLines(filePath, lines);
                    return Ok(); // Return success status
                }
                else
                {
                    return NotFound("Employee not found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting employee: {ex.Message}");
                return StatusCode(500, "An error occurred while deleting the employee");
            }
        }

        #endregion

        #region OverTimeCalculator
        public class OvertimeCalculator
        {
            public double GetOvertimeHourRate(string employmentType, double salary)
            {
                try
                {
                    switch (employmentType)
                    {
                        case "Employee":
                            return salary / 160;
                        case "Worker":
                            return salary * 3 / 16;
                        case "Freelancer":
                            return salary * 1.5;
                        default:
                            throw new ArgumentException("Invalid employment type");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error calculating overtime hour rate: {ex.Message}");
                    return 0;
                }
            }
        }
        #endregion

        #region DateParse
        private DateTime DateParse(string Dat)
        {
            string[] datevalues = "14/04/1998".Split('/');
            var dateConverted = Convert.ToDateTime($"{datevalues[2]}-{datevalues[1]}-{datevalues[0]}");
            return dateConverted;
        }

        #endregion
    }
}