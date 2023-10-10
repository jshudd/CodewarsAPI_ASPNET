namespace CodewarsAPI_ASPNET.Tests;

public class ApiTests
{
    [Theory]
    [InlineData("jshudd")]
    [InlineData("chipelmer")]
    [InlineData("Bryantellius")]
    [InlineData("TheMrChaptastic")]
    [InlineData("mvdoyle")]
    [InlineData("amoriss")]
    [InlineData("CruzSanchez")]
    [InlineData("whitstroup")]
    public void ApiCallDoesReturnData_SUCCESS(string userName)
    {
        var result = Api.CallApi(userName);

        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("jshuddabcdefg")]
    public void ApiCallDoesNOTReturnData(string userName)
    {
        Assert.Throws<AggregateException>(() => Api.CallApi(userName));
    }
}
