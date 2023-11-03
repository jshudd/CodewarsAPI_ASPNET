using System;
namespace CodewarsAPI_ASPNET.Tests
{
	public class MyFixtures : IDisposable
	{
        public IApiRepo ApiRepo { get; }

        public MyFixtures()
		{
            ApiRepo = new ApiRepo();
        }

        public IApiRepo GetApiRepo()
        {
            return ApiRepo; // Return the configured IApiRepo instance
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

