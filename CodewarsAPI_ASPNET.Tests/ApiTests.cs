namespace CodewarsAPI_ASPNET.Tests;

public class APITests
{
    private readonly IApiRepo _repo;

    public APITests(MyFixtures fixture)
    {
        this._repo = fixture.GetApiRepo();
    }

    [Theory]
    [InlineData("jshudd")]
    [InlineData("chipelmer")]
    [InlineData("Bryantellius")]
    [InlineData("TheMrChaptastic")]
    [InlineData("mvdoyle")]
    [InlineData("amoriss")]
    [InlineData("CruzSanchez")]
    [InlineData("whitstroup")]
    public void APICallDoesReturnData_SUCCESS(string userName)
    {
        var result = _repo.CallApi(userName);

        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("jshuddabcdefg")]
    public void APICallDoesNOTReturnData(string userName)
    {
        Assert.ThrowsAsync<AggregateException>(() => _repo.CallApi(userName));
    }
}
