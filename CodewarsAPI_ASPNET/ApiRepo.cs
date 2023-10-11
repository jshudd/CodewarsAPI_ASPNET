using System;

namespace CodewarsAPI_ASPNET
{
	public class ApiRepo : IApiRepo
	{
		public ApiRepo()
		{
		}

        public async Task<string> CallApi(string userName)
        {
            var cwURL = $"https://www.codewars.com/api/v1/users/{userName}";

            var client = new HttpClient();

            try
            {
                return await client.GetStringAsync(cwURL);
            }
            catch (AggregateException)
            {
                throw new AggregateException();
            }
        }
    }
}

