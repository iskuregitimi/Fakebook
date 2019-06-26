﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.CoreUI.Models
{
	public class PersonModel
	{
		[Key]
		public int PersonID { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public DateTime BirthDate { get; set; }
		public string Gender { get; set; }
		public string Image { get; set; }

	}
}
