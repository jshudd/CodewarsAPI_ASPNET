﻿using System;
namespace CodewarsAPI_ASPNET
{
	public interface ICsvRepo
	{
		public IEnumerable<string>? ReadCsv(string fileName);
		public IEnumerable<string>? RetrieveCsvFileNames();
		//public bool VerifyVaildFileName(string fileName); // used to prevent duplicate filenames
	}
}

