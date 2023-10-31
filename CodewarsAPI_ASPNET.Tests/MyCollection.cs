using System;
namespace CodewarsAPI_ASPNET.Tests
{
    [CollectionDefinition("MyCollection")]
    public class MyCollection : ICollectionFixture<MyFixtures>
    {
        // no code necessary because it serves as a marker for the collection fixture
    }
}

