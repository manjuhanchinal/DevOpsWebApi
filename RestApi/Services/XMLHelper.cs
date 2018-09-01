using RestApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RestApiDemo.Services
{
    public class XMLHelper
    {
        string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\Employees.xml";
        XDocument xmldoc;
        public XMLHelper()
        {
            xmldoc = XDocument.Load(filePath);
        }        
        public List<Employee> GetEmpList()
        {
            var bind = xmldoc.Descendants("Employee").Select(p => new
            {
                Id = p.Element("id").Value,
                Name = p.Element("name").Value,
                Designation = p.Element("designation").Value,

            }).OrderBy(p => p.Id);
            var empList = new List<Employee>();
            foreach (var item in bind)
            {
                empList.Add(new Employee { Id = item.Id, Name = item.Name, Designation = item.Designation });
            }
            return empList;

        }

        public List<Employee> CreateEmployee(Employee employee)
        {
            XElement emp = new XElement("Employee",
                     new XElement("id", employee.Id),
                     new XElement("name", employee.Name),
                     new XElement("designation", employee.Designation)
                     );
            xmldoc.Root.Add(emp);
            xmldoc.Save(filePath);
            return GetEmpList();
        }

        public List<Employee> UpdateEmployee(Employee employee)
        {
            XElement empdoc = xmldoc.Descendants("Employee").FirstOrDefault(p => p.Element("id").Value == employee.Id);
            if (empdoc != null)
            {
                empdoc.Element("name").Value = employee.Name;
                empdoc.Element("designation").Value = employee.Designation;
                //xmldoc.Root.SetValue(empdoc);
                xmldoc.Save(filePath);
            }
            return GetEmpList();
        }

        public List<Employee> DeleteEmployee(string id)
        {

            XElement empDoc = xmldoc.Descendants("Employee").FirstOrDefault(p => p.Element("id").Value == id);
            if (empDoc != null)
            {
                empDoc.Remove();
                xmldoc.Save(filePath);
            }
            return GetEmpList();
        }

        public Employee GetEmployee(string id)
        {
            return GetEmpList().Find(emp => emp.Id == id);
        }

    }
}