using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic_Layer.Models
{
	public class EmployeeModel
	{

		//public int Id { get; set; }

		//[RegularExpression(@"\A[^\d_]+\z", ErrorMessage = "Invalid Data Type")]
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Address { get; set; }
		[StringLength(10, ErrorMessage = "Phone number cannot be longer than 10 digits.")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits long.")]
		public string PhoneNumber { get; set; }
		[DataType(DataType.Date)]
		public DateTime? DateOfBirth { get; set; }
	}
}
