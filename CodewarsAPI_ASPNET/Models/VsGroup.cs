using System;
namespace CodewarsAPI_ASPNET.Models
{
	public class VsGroup
	{
		public VsGroup(string fileNameA, string fileNameB)
		{
			FileNameA = fileNameA;
			FileNameB = fileNameB;
		}

		public string FileNameA { get; set; }
        public string FileNameB { get; set; }

		public Group GroupA
		{
			get;
			set;
		}

		public Group GroupB { get; set; }
	}
}

