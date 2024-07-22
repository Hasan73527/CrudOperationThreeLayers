using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
	public class EmployeeDAL
	{
		public List<Employee> GetAllEmployees()
		{
			var db = new EmployeeDbContext();
			return db.Employee.ToList();
		}

		public Employee GetEmployeeById(int id)
		{
			var db = new EmployeeDbContext();
			Employee p = new Employee();

			p = db.Employee.FirstOrDefault(x => x.Id == id);

			return p;
		}

		
		public void postEmployee(Employee Employee)
		{
			var db = new EmployeeDbContext();
			db.Add(Employee);
			db.SaveChanges();
		}

	}
}
