using CSDomain;
using Services;

namespace UnitTests;

public class PfaTest
{
    
    [Theory]
    [InlineData("TestConfig.csv")]
    [InlineData("TestConfig2.csv")]
    public void Test_ReadConfiguration(string testConfigFilePath)
	{
		var serv = new ConfigurationService();
		var c = serv.ReadFromPath(Environment.CurrentDirectory, testConfigFilePath);

		Assert.True(!string.IsNullOrWhiteSpace(c.ConfigfilePath));
		Assert.True(c.Datamappings.Any());
		Assert.True(c.ValueMappings.Any());
	}


	[Fact]
    public void Test_SplitPath()
    {
        var filepath = "this/is/my/path/to/my.file";
        
        var filename = PathHelper.GetFileName(filepath);
        Assert.Equal("my.file", filename);
        
        var dirpath = PathHelper.GetDirectoryPath(filepath);
        Assert.Equal("this/is/my/path/to", dirpath);
    }

    [Fact]
    public void Test_ReadConfiguration_File1()
    {
        string testConfigFilePath="TestConfig.csv";
        Assert.True(File.Exists(Path.Combine(Environment.CurrentDirectory, testConfigFilePath)));

        var serv = new ConfigurationService();
        var c = serv.ReadFromPath(Environment.CurrentDirectory, testConfigFilePath);

        Assert.NotNull(c);

        Assert.True(!string.IsNullOrEmpty(c.ConfigfilePath));
        Assert.True(!string.IsNullOrEmpty(c.Datafilenames.FirstOrDefault()));

        Assert.True(c.Datamappings.Count == 5);

        Assert.True(c.Datamappings.ContainsKey("Date"));
        var datemapping = c.Datamappings.SingleOrDefault(dm => dm.Key.Equals("Date"));
        Assert.True(datemapping.Value.ColumnIndex == 0);
        var valuemapping = c.Datamappings.SingleOrDefault(dm => dm.Key.Equals("Value"));
        Assert.True(valuemapping.Value.ColumnIndex == 1);
        var subjectmapping = c.Datamappings.SingleOrDefault(dm => dm.Key.Equals("Subject"));
        Assert.True(subjectmapping.Value.ColumnIndex == 2);
        var receivermapping = c.Datamappings.SingleOrDefault(dm => dm.Key.Equals("Receiver"));
        Assert.True(receivermapping.Value.ColumnIndex == 3);
        var descriptionmapping = c.Datamappings.SingleOrDefault(dm => dm.Key.Equals("Description"));
        Assert.True(descriptionmapping.Value.ColumnIndex == 4);

        Assert.True(c.ValueMappings.Count == 6);

        var living = c.ValueMappings.Where(vm => vm.Category.Equals("Wohnen"));
        Assert.True(living.Count() == 3);
        Assert.Contains(living, m => m.Keyword.Equals("Miete"));
        Assert.Contains(living, m => m.Keyword.Equals("Strom"));
        Assert.Contains(living, m => m.Keyword.Equals("Glasfaser"));

        var food = c.ValueMappings.Where(vm => vm.Category.Equals("Nahrung"));
        Assert.True(food.Count() == 3);
        Assert.Contains(food, m => m.Keyword.Equals("Aldi"));
        Assert.Contains(food, m => m.Keyword.Equals("Rewe"));
        Assert.Contains(food, m => m.Keyword.Equals("Edeka"));
    }

    [Fact]
    public void Test_ReadConfiguration_File2()
    {
        string testConfigFilePath="TestConfig2.csv";
        Assert.True(File.Exists(Path.Combine(Environment.CurrentDirectory, testConfigFilePath)));

        var serv = new ConfigurationService();
        var c = serv.ReadFromPath(Environment.CurrentDirectory, testConfigFilePath);

        Assert.NotNull(c);

        Assert.True(!string.IsNullOrEmpty(c.ConfigfilePath));
        Assert.True(!string.IsNullOrEmpty(c.Datafilenames.FirstOrDefault()));

        Assert.True(c.Datamappings.Count == 3);

        Assert.True(c.Datamappings.ContainsKey("Date"));
        var datemapping = c.Datamappings.SingleOrDefault(dm => dm.Key.Equals("Date"));
        Assert.True(datemapping.Value.ColumnIndex == 2);
        var valuemapping = c.Datamappings.SingleOrDefault(dm => dm.Key.Equals("Value"));
        Assert.True(valuemapping.Value.ColumnIndex == 0);
        var subjectmapping = c.Datamappings.SingleOrDefault(dm => dm.Key.Equals("Subject"));
        Assert.True(subjectmapping.Value.ColumnIndex == 1);

        Assert.True(c.ValueMappings.Count == 4);

        var mobility = c.ValueMappings.Where(vm => vm.Category.Equals("Mobility"));
        Assert.True(mobility.Count() == 2);
        Assert.Contains(mobility, m => m.Keyword.Equals("Kfz Versicherung"));
        Assert.Contains(mobility, m => m.Keyword.Equals("Deutschlandticket"));

        var leisure = c.ValueMappings.Where(vm => vm.Category.Equals("Leisure"));
        Assert.True(leisure.Count() == 1);
        Assert.Contains(leisure, m => m.Keyword.Equals("TV Sportenhausen"));

        var education = c.ValueMappings.Where(vm => vm.Category.Equals("Education"));
        Assert.True(education.Count() == 1);
        Assert.Contains(education, m => m.Keyword.Equals("OGS Träger Sportenhausen"));        
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