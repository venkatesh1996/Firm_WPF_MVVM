using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MvvmDemoRemastered.Models
{
    class Employeeservice
    {
        private static List<Employee> ObjEmployeesList;
        public Employeeservice()
        {
            ObjEmployeesList = new List<Employee>()
            {
                new Employee{Id=101,Name="Venk",Age=24}
            };
        }
        public List<Employee> GetAll()
        {
            return ObjEmployeesList;
        }
        public bool Add(Employee ObjNewEmployee)
        {
            //age must between 21 and 58
            if(ObjNewEmployee.Age<21 || ObjNewEmployee.Age>58)
            {
                throw new ArgumentException("Invalid Age Limit for Employee");
            }
            ObjEmployeesList.Add(ObjNewEmployee);
            return true;
        }
        public bool Update(Employee ObjNewEmployee)
        {
            bool IsUpdated=false;
            for(int index=0;index< ObjEmployeesList.Count;index++)
            {
                if(ObjEmployeesList[index].Id== ObjNewEmployee.Id)
                {
                    ObjEmployeesList[index].Name = ObjNewEmployee.Name;
                    ObjEmployeesList[index].Age = ObjNewEmployee.Age;
                    IsUpdated = true;
                    break;
                } 
            }
            return IsUpdated;
        }
        public bool  Delete(int id)
        {
            bool IsDeleted = false;
            for (int index = 0; index < ObjEmployeesList.Count; index++)
            {
                if (ObjEmployeesList[index].Id == id)
                {
                    ObjEmployeesList.RemoveAt(index);
                    IsDeleted = true;
                }
            }
            return IsDeleted;
        }
        public Employee Search(int id)
        {
            return ObjEmployeesList.FirstOrDefault(e=>e.Id==id);
        }
    }
}
