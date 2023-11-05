using System;

namespace CodewarsAPI_ASPNET
{
	public class CsvRepo : ICsvRepo
	{
		public CsvRepo()
		{
		}

        private static string _relativeDirPath = "/wwwroot/csvFiles";
        private readonly string _dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativeDirPath);

        public IEnumerable<string>? RetrieveCsvFileNames()
        {
            var fileNameList = new List<string>();

            if (Directory.Exists(_dirPath))
            {
                fileNameList = Directory.GetFiles(_dirPath).ToList();

                for (var i = 0; i < fileNameList.Count(); i++)
                {
                    fileNameList[i] = Path.GetFileNameWithoutExtension(fileNameList[i]);
                }
            }
            else
            {
                return null;
            }

            return fileNameList;
        }
    }
}

