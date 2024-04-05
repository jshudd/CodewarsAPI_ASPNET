using System;
namespace CodewarsAPI_ASPNET.Models
{
	public class Admin
	{
		public Admin()
		{
		}

		public bool IsCorrectPW { get; set; }
		public string UserName { get; set; }
		public string PW { get; set; }
	}
}

