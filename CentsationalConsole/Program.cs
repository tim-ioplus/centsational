using Account.Service;

namespace CentsationalConsole;

class Program
{
private const string DATA_FILEPATH_KEY = "CENTSATIONAL_INPUT_PATH";

private static string CONFIG_FILEPATH_KEY = "CENTSATIONAL_CONFIG_PATH";


static void Main(string[] args)
{
    string? data_path = Environment.GetEnvironmentVariable(DATA_FILEPATH_KEY);
    string? config_path = Environment.GetEnvironmentVariable(CONFIG_FILEPATH_KEY);

    if (string.IsNullOrEmpty(data_path))
    {
        Console.WriteLine("Please provide the path to the directory from where to read your Document.");
        data_path = Console.ReadLine();
    }

    if (string.IsNullOrEmpty(config_path))
    {
        Console.WriteLine("Please provide the path to the directory where your Configuration resides.");
        config_path = Console.ReadLine();
    }

    if (string.IsNullOrEmpty(data_path)) return;
    if (string.IsNullOrEmpty(config_path)) return;

    var accountService = new AccountService();
    var configuration = accountService.ReadConfiguration(config_path);

    var result = accountService.ReadTransactions(configuration, data_path);

    var mappingResult = accountService.MapTransactions();

    Console.WriteLine("Sorted with value Mappings:");

    
}
}