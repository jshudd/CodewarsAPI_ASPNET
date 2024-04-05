using System;
namespace CodewarsAPI_ASPNET.Models
{
	public class Admin
	{
		public Admin()
		{
		}

		public bool IsCorrectPW { get; set; } = false;
		public string UserName { get; set; }
		public string PW { get; set; }
	}
}

