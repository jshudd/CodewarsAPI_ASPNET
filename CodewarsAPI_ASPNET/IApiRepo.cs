using System;
namespace CodewarsAPI_ASPNET
{
	public interface IApiRepo
	{
		public Task<string> CallApi(string userName);
	}
}

