using Account.Domain;

namespace Account.Service.Tests;

public class AccountTest
{
    
    [Fact]
    public void Test_ReadConfiguration()
    {
        var serv = new AccountService();
        var c = serv.ReadConfiguration("/my/path/to/nowwhere");

        Console.WriteLine("Cu dir: " + Environment.CurrentDirectory.ToString());

        Assert.True(!string.IsNullOrWhiteSpace(c.ConfigfilePath));        
    }

    [Fact]
    public void Test_SumAccount()
    {
        var transactions = new List<Transaction>();
        decimal expected = 0;
        for (int i = 0; i < 10; i++)
        {
            decimal amount = i + 1;
            var t = new Transaction();
            t.Value = amount;
            t.Subject = "Test";
            t.Description = "i = " + i;

            transactions.Add(t);
            expected += amount;
        }

        decimal actual = new AccountService().SumAccount(transactions);
        Console.WriteLine("{0} {1}", expected, actual);
        Assert.Equal(expected, actual);
    }
}