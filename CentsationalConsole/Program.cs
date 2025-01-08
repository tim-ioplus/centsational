using Services;

namespace CentsationalConsole;

class Program
{
	private const string DATA_FILEPATH_KEY = "CENTSATIONAL_INPUT_PATH";
	private const string testDataPaths = "C:\\Users\\T14\\Documents\\GitHub\\centsational\\AccountService.Tests";
	private static string CONFIG_FILEPATH_KEY = "CENTSATIONAL_CONFIG_PATH";


	static void Main(string[] args)
	{
		string? current_path = "";
		string? data_path = Environment.GetEnvironmentVariable(DATA_FILEPATH_KEY);
		string? config_path = Environment.GetEnvironmentVariable(CONFIG_FILEPATH_KEY);

		var isLocalRun = Environment.MachineName.Contains("finity") || Environment.MachineName.Contains("JQTJ275");
		if (isLocalRun)
		{
			//current_path = string.Format(Environment.CurrentDirectory.Replace("CentsationalConsole\\", "")) + "\\AccountService.Tests\\"; 
			current_path = Path.Combine(testDataPaths);
			data_path = Path.Combine(current_path, "TestData.csv");
			config_path = Path.Combine(current_path, "TestConfig.csv");
		}

		if (string.IsNullOrEmpty(data_path))
		{
			Console.WriteLine("Please provide the path to the Data Document.");
			data_path = Console.ReadLine();
		}

		if (string.IsNullOrEmpty(config_path))
		{
			Console.WriteLine("Please provide the path to the Configuration Document.");
			config_path = Console.ReadLine();
		}

		if (string.IsNullOrEmpty(data_path)) return;
		if (string.IsNullOrEmpty(config_path)) return;

		var configationService = new ConfigurationService();
		var configuration = configationService.ReadFromPath(current_path, "TestConfig.csv");

		if (configuration == null || !configuration.Validate())
		{
			Console.WriteLine();
			return;
		}
		else
		{
			var accountService = new AccountService();
			var result = accountService.ReadTransactions(configuration);
			accountService.Configuration = configuration;
			var mappingResult = accountService.MapTransactions();
			Console.WriteLine("Sorted with value Mappings:");

			foreach (var account in mappingResult)
			{
				Console.WriteLine("Account: " + account.Key);
				foreach (var transaction in account.Value)
				{
					Console.WriteLine(transaction.ToString());
				}
				Console.WriteLine();
			}

			accountService.SumAccounts(mappingResult, true);
		}
	}
}