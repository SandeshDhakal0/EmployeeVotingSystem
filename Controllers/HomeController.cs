using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeVotingSystem.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeVotingSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


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

