using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{

	public partial class Employee
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }
		[Column("first_name")]
		[StringLength(100)]

		public string FirstName { get; set; }
		[Column("last_name")]
		[StringLength(100)]
		public string LastName { get; set; }
		[Column("address")]
		[StringLength(1000)]
		public string Address { get; set; }
		[Column("phone_number")]
		[StringLength(100)]
		public string PhoneNumber { get; set; }
		[Column("date_of_birth", TypeName = "date")]
		[DataType(DataType.Date)]
		public DateTime? DateOfBirth { get; set; }


	}
}
