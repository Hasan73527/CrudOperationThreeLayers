using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository;

namespace CrudOperatiomLayers.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{

		private Business_Logic_Layer.EmployeeBLL _BLL;
		public EmployeeController()
		{
			_BLL = new Business_Logic_Layer.EmployeeBLL();
		}


		[HttpGet]
		[Route("GetAllEmployees")]


		public List<EmployeeModel> GetAllEmployees()
		{
			return _BLL.GetAllEmployees();
		}



		[HttpGet]
		[Route("GetEmployee")]
		public ActionResult<EmployeeModel> GetEmployeeById(int id)
		{
			var Employee = _BLL.GetEmployeeById(id);

			if (Employee == null)
			{
				return NotFound("Invalid ID");
			}

			return Ok(Employee);
		}




		[Route("CreateEmployee")]
		[HttpPost]
		//public void postEmployee([FromBody] EmployeeModel EmployeeModel)
		//{
		//	_BLL.postEmployee(EmployeeModel);
		//}
		public IActionResult postEmployee([FromBody] EmployeeModel EmployeeModel)
		{
			_BLL.postEmployee(EmployeeModel);

			return Ok("Employee Details successfully saved");
		}

		[Route("updateEmployee")]
		[HttpPut]
		public IActionResult UpdateEmployee(int id, [FromBody] EmployeeModel updatedEmployee)
		{
			try
			{
				using (var db = new EmployeeDbContext())
				{
					var existingEmployee = db.Employee.FirstOrDefault(x => x.Id == id);

					if (existingEmployee == null)
						return NotFound(new { message = "Please Enter Valid Id Employee not found." });

					// Update the properties of the existing Employee with the values from the updatedEmployee object
					existingEmployee.FirstName = updatedEmployee.FirstName;
					existingEmployee.LastName = updatedEmployee.LastName;
					existingEmployee.Address = updatedEmployee.Address;
					existingEmployee.PhoneNumber = updatedEmployee.PhoneNumber;
					existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;

					db.SaveChanges();
					return NoContent();
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while updating the Employee.", details = ex.Message });
			}
		}
		//public void UpdateEmployee(int id, [FromBody] EmployeeModel updatedEmployee)
		//{
		//	var db = new EmployeeDbContext();
		//	Employee existingEmployee = db.Employee.FirstOrDefault(x => x.Id == id);

		//	if (existingEmployee == null)
		//	throw new Exception("Not found");

		//	// Update the properties of the existing Employee with the values from the updatedEmployee object
		//	existingEmployee.FirstName = updatedEmployee.FirstName;
		//	existingEmployee.LastName = updatedEmployee.LastName;
		//	existingEmployee.Address = updatedEmployee.Address;
		//	existingEmployee.PhoneNumber = updatedEmployee.PhoneNumber;
		//	existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;
		//	// Add any other properties that need to be updated

		//	db.SaveChanges();
		//}


		//(This is the bad practise!) = > this should instead also call the BLL 
		[Route("deleteEmployee")]
		[HttpDelete]
		public IActionResult deleteEmployee(int id)
		{
			using (var db = new EmployeeDbContext())
			{
				var Employee = db.Employee.FirstOrDefault(x => x.Id == id);

				if (Employee == null)
				{
					return NotFound("Employee not found");
				}

				db.Employee.Remove(Employee);
				db.SaveChanges();

				return Ok("Employee details successfully deleted");
			}
		}
		//public void deleteEmployee(int id)
		//{
		//	var db = new EmployeeDbContext();
		//	Employee p = new Employee();
		//	p = db.Employee.FirstOrDefault(x => x.Id == id);

		//	if (p == null)
		//		throw new Exception("Not found");

		//	db.Employee.Remove(p);
		//	db.SaveChanges();
		//}


	}
}
//{
//	[ApiController]
//	[Route("[controller]")]
//	public class EmployeeController : ControllerBase
//	{

//		private Business_Logic_Layer.EmployeeBLL _BLL;
//		public EmployeeController()
//		{
//			_BLL = new Business_Logic_Layer.EmployeeBLL();
//		}


//		[HttpGet]
//		[Route("getEmployees")]


//		public List<EmployeeModel> GetAllEmployees()
//		{
//			return _BLL.GetAllEmployees();
//		}



//		[HttpGet]
//		[Route("getEmployee")]
//		public ActionResult<EmployeeModel> GetEmployeeById(int id)
//		{
//			var Employee = _BLL.GetEmployeeById(id);

//			if (Employee == null)
//			{
//				return NotFound("Invalid ID");
//			}

//			return Ok(Employee);
//		}




//		[Route("postEmployee")]
//		[HttpPost]
//		public void postEmployee([FromBody] EmployeeModel EmployeeModel)
//		{
//			_BLL.postEmployee(EmployeeModel);
//		}

//		[Route("updateEmployee")]
//		[HttpPut]
//		public void UpdateEmployee(int id, [FromBody] EmployeeModel updatedEmployee)
//		{
//			var db = new EmployeeDbContext();
//			Employee existingEmployee = db.Employee.FirstOrDefault(x => x.Id == id);

//			if (existingEmployee == null)
//				throw new Exception("Not found");

//			// Update the properties of the existing Employee with the values from the updatedEmployee object
//			existingEmployee.FirstName = updatedEmployee.FirstName;
//			existingEmployee.LastName = updatedEmployee.LastName;
//			existingEmployee.Address = updatedEmployee.Address;
//			existingEmployee.PhoneNumber = updatedEmployee.PhoneNumber;
//			existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;
//			// Add any other properties that need to be updated

//			db.SaveChanges();
//		}


//		//(This is the bad practise!) = > this should instead also call the BLL 
//		[Route("deleteEmployee")]
//		[HttpDelete]
//		public void deleteEmployee(int id)
//		{
//			var db = new EmployeeDbContext();
//			Employee p = new Employee();
//			p = db.Employee.FirstOrDefault(x => x.Id == id);

//			if (p == null)
//				throw new Exception("Not found");

//			db.Employee.Remove(p);
//			db.SaveChanges();
//		}


//	}
//}
