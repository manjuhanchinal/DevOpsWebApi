using RestApiDemo.Models;
using System.Collections.Generic;

namespace RestApiDemo.Services
{
    public class EmployeeService
    {
        public readonly XMLHelper xmlHelperClient;
        public EmployeeService()
        {
            xmlHelperClient = new XMLHelper();
        }

        public Employee GetEmployeeDetails(int id)
        {
            return xmlHelperClient.GetEmployee(id.ToString());
        }

        public List<Employee> GetEmployeeList()
        {
            return xmlHelperClient.GetEmpList();
        }

        public List<Employee> CreateEmployee(Employee emp)
        {
            return xmlHelperClient.CreateEmployee(emp);
        }
        public List<Employee> UpdateEmployee(Employee emp)
        {
            return xmlHelperClient.UpdateEmployee(emp);
        }

        public List<Employee> DeleteEmployee(int id)
        {
            return xmlHelperClient.DeleteEmployee(id.ToString());
        }
    }
}