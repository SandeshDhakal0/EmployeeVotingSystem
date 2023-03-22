using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeVotingSystem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeVotingSystem.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;
    public HomeController(ApplicationDbContext context, ILogger<HomeController> logger, IConfiguration configuration)
    {
        _context = context;
        _logger = logger;
        _configuration = configuration;
    }

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}


    public IActionResult Index()
    {
        var employees = _context.Employee
            .Select(e => new { e.employeeid, e.employeename })
            .Distinct()
            .OrderBy(e => e.employeename)
            .ToList();

        ViewBag.Employees = employees;

        return View();
    }


    [HttpPost]
    public IActionResult Index(string employeeid)
    {
        // Create an empty list to hold the employee history data
        var employeeHistory = new List<EmployeeHistoryViewModel>();

        // Use the SQL query to populate the employee history data
        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var query = @"SELECT eh.historyid, eh.employeeid, e.employeename, e.dob AS dob,
                      eh.departmentid, d.departmentname, d.description, eh.roleid, eh.startdate, eh.enddate
                      FROM employeehistory AS eh
                      JOIN employee AS e ON eh.employeeid = e.employeeid
                      JOIN department AS d ON eh.departmentid = d.departmentid
                      WHERE eh.employeeid = @employeeid
                      AND eh.enddate IS NOT NULL";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeid", employeeid);

            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var history = new EmployeeHistoryViewModel
                {
                    historyid = reader["historyid"].ToString(),
                    employeeid = reader["employeeid"].ToString(),
                    employeename = reader["employeename"].ToString(),
                    dob = Convert.ToDateTime(reader["dob"]),
                    departmentid = reader["departmentid"].ToString(),
                    departmentname = reader["departmentname"].ToString(),
                    description = reader["description"].ToString(),
                    roleid = reader["roleid"].ToString(),
                    startdate = Convert.ToDateTime(reader["startdate"]),
                    enddate = Convert.ToDateTime(reader["enddate"])
                };

                employeeHistory.Add(history);
            }

            reader.Close();
        }

        // Pass the employee history data to the view
        return View(employeeHistory);
    }

    //[HttpPost]
    //public IActionResult GetVoterRecord(string voterid)
    //{
    //    var voterRecord = new List<VoterRecordViewModel>();

    //    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
    //    {
    //        var query = @"SELECT VR.RECORDID, VR.VOTERID, E.EMPLOYEENAME, E.DOB, E.CONTACT, VR.CANDIDATEID, 
    //                  C.EMPLOYEENAME AS CANDIDATENAME, C.CONTACT AS CANDIDATECONTACT, VR.VOTINGYEAR, VR.VOTINGMONTH
    //                  FROM VOTERECORD VR
    //                  JOIN EMPLOYEE E ON VR.VOTERID = E.EMPLOYEEID
    //                  JOIN EMPLOYEE C ON VR.CANDIDATEID = C.EMPLOYEEID
    //                  WHERE VR.VOTERID = @voterId";

    //        var command = new SqlCommand(query, connection);
    //        command.Parameters.AddWithValue("@voterId", voterid);

    //        connection.Open();

    //        var reader = command.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            var record = new VoterRecordViewModel
    //            {
    //                recordid = reader["RECORDID"].ToString(),
    //                voterid = reader["VOTERID"].ToString(),
    //                votername = reader["EMPLOYEENAME"].ToString(),
    //                dob = Convert.ToDateTime(reader["DOB"]),
    //                candidateid = reader["CANDIDATEID"].ToString(),
    //                candidatename = reader["CANDIDATENAME"].ToString(),
    //                candidatecontact = reader["CANDIDATECONTACT"].ToString(),
    //                votingyear = reader["VOTINGYEAR"].ToString(),
    //                votingmonth = reader["VOTINGMONTH"].ToString()
    //            };

    //            voterRecord.Add(record);
    //        }

    //        reader.Close();
    //    }

    //    return View(voterRecord);
    //}



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public ActionResult GetEmployeeCount()
    {
        string connectionString = "server =localhost,1433; database=voting; User=sa; Password=P@ssw0rd; TrustServerCertificate=true;";
        SqlConnection connection = new SqlConnection(connectionString);
        string sql = "SELECT COUNT(*) FROM employee";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        int count = (int)command.ExecuteScalar();
        connection.Close();

        return Content(count.ToString());
    }

    public ActionResult GetDepartmentCount()
    {
        string connectionString = "server =localhost,1433; database=voting; User=sa; Password=P@ssw0rd; TrustServerCertificate=true;";
        SqlConnection connection = new SqlConnection(connectionString);
        string sql = "SELECT COUNT(*) FROM department";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        int count = (int)command.ExecuteScalar();
        connection.Close();

        return Content(count.ToString());
    }

    public ActionResult GetJobCount()
    {
        string connectionString = "server =localhost,1433; database=voting; User=sa; Password=P@ssw0rd; TrustServerCertificate=true;";
        SqlConnection connection = new SqlConnection(connectionString);
        string sql = "SELECT COUNT(*) FROM job";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        int count = (int)command.ExecuteScalar();
        connection.Close();

        return Content(count.ToString());
    }

    public ActionResult GetRoleCount()
    {
        string connectionString = "server =localhost,1433; database=voting; User=sa; Password=P@ssw0rd; TrustServerCertificate=true;";
        SqlConnection connection = new SqlConnection(connectionString);
        string sql = "SELECT COUNT(*) FROM role";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        int count = (int)command.ExecuteScalar();
        connection.Close();

        return Content(count.ToString());
    }

    public ActionResult GetRecordCount()
    {
        string connectionString = "server =localhost,1433; database=voting; User=sa; Password=P@ssw0rd; TrustServerCertificate=true;";
        SqlConnection connection = new SqlConnection(connectionString);
        string sql = "SELECT COUNT(*) FROM voterecord";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        int count = (int)command.ExecuteScalar();
        connection.Close();

        return Content(count.ToString());
    }

    public ActionResult GetManagerCount()
    {
        string connectionString = "server =localhost,1433; database=voting; User=sa; Password=P@ssw0rd; TrustServerCertificate=true;";
        SqlConnection connection = new SqlConnection(connectionString);
        string sql = "SELECT COUNT(*) FROM manager";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        int count = (int)command.ExecuteScalar();
        connection.Close();

        return Content(count.ToString());
    }


}

