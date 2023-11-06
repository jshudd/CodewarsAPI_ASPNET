using System;

namespace CodewarsAPI_ASPNET
{
	public class CsvRepo : ICsvRepo
	{
		public CsvRepo()
		{
		}

        private static string _relativeDirPath = "wwwroot/csvFiles";
        //private readonly string _dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativeDirPath);

        public IEnumerable<string>? ReadCsv(string fileName) => File.ReadAllLinesAsync($"{_relativeDirPath}/{fileName}.csv").Result.ToList();

        public IEnumerable<string>? RetrieveCsvFileNames()
        {
            var fileNameList = new List<string>();

            if (Directory.Exists(_relativeDirPath))
            {
                fileNameList = Directory.GetFiles(_relativeDirPath).ToList();

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

