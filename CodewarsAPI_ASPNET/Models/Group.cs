using System;
namespace CodewarsAPI_ASPNET.Models
{
	public class Group
	{
		public Group()
		{
		}

		public Group(List<User> userGroup)
		{
			UserGroup = userGroup;
		}

		public string? Name { get; set; }

		public IEnumerable<User> UserGroup { get; set; }
	}
}

