using System;
using Newtonsoft.Json;

namespace CodewarsAPI_ASPNET
{
	public class ApiRepo : IApiRepo
	{
		public ApiRepo()
		{
		}

        // Deserialize code
        // User myDeserializedClass = JsonConvert.DeserializeObject<User>(myJsonResponse);

        public async Task<string> CallApi(string userName)
        {
            var cwURL = $"https://www.codewars.com/api/v1/users/{userName}";

            var client = new HttpClient();

            try
            {
                return await client.GetStringAsync(cwURL);
            }
            catch (HttpRequestException)
            {
                return "incorrect";
            }
        }

        public User DeserializeJson(string json)
        {
            return JsonConvert.DeserializeObject<User>(json);
        }
    }
}

