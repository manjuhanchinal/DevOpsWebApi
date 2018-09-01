using RestApiDemo.Models;
using RestApiDemo.Services;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("employee")]
    public class EmployeeApiController : ApiController
    {
        public readonly EmployeeService employeeServiceClient ;
        public EmployeeApiController()
        {
            employeeServiceClient = new EmployeeService();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetEmployeeList()
        {
           var empList= employeeServiceClient.GetEmployeeList();
            return Ok(empList);
        }

        [Route("search")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]int id)
        {
            var emp = employeeServiceClient.GetEmployeeDetails(id);
            return Ok(emp);
        }
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Employee emp)
        {
            var empList = employeeServiceClient.CreateEmployee(emp);
            return Ok(empList);
        }
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put([FromBody]Employee emp)
        {
            var empList = employeeServiceClient.UpdateEmployee(emp);
            return Ok(empList);
        }
        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var empList = employeeServiceClient.DeleteEmployee(id);
            return Ok(empList);
        }
    }
}
