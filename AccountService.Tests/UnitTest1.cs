namespace Account.Service.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var serv = new AccountService();
        bool result = serv.IsEven(1);

        Assert.False(result, "1 is not even.");
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    public void Test_IsEven(int candidate, bool expectedResult)
    {
        var serv = new AccountService();
        bool result = serv.IsEven(candidate);

        Assert.Equal(expectedResult, result);
    }
}