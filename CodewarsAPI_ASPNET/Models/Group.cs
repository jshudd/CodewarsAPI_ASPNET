﻿using System;
namespace CodewarsAPI_ASPNET.Models
{
	public class Group
	{
		public Group()
		{
		}

		public Group(string name, List<User> userGroup)
		{
			Name = name;
			UserGroup = userGroup;
		}

		public string? Name { get; set; }
		public int? Number
		{
			get => UserGroup.Count();
		}

		public List<User> UserGroup { get; set; }
	}
}

