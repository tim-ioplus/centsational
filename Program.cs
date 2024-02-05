using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace HelloWorld;

class Program
{
    private const string DATA_FILEPATH_KEY = "CENTSATIONAL_INPUT_PATH";

    private static string CONFIG_FILEPATH_KEY = "CENTSATIONAL_CONFIG_PATH";


    static void Main(string[] args)
    {
        var _transactions = new List<Transaction>();

        Console.WriteLine("Hello, World!");
        string? data_path = Environment.GetEnvironmentVariable(DATA_FILEPATH_KEY);
        string? config_path = Environment.GetEnvironmentVariable(CONFIG_FILEPATH_KEY);

        if (string.IsNullOrEmpty(data_path))
        {
            Console.WriteLine("Please provide the path to the directory from where toread your Document.");
            data_path = Console.ReadLine();
        }

        if (string.IsNullOrEmpty(config_path))
        {
            Console.WriteLine("Please provide the path to the directory where your Configuration resides.");
            config_path = Console.ReadLine();
        }

        if (string.IsNullOrEmpty(data_path)) return;
        if (string.IsNullOrEmpty(config_path)) return;

        var configfilename = Path.GetFileName(config_path);
        Config? config = null;
        if (!string.IsNullOrEmpty(configfilename))
        {
            config = new Config().FromPath(configfilename);
        }
        else
        {
            Console.WriteLine("No Configuraiton found. exit.");
            return;
            // or maybe use some Default configuration?
        }

        if (config == null)
        {
            Console.WriteLine("No configuraiton provided. exit.");
            return;
        }
        if (!config.Validate())
        {
            Console.Write("Configuration data is invalid. exit.");
            return;
        }

        var dataFileName = Path.GetFileName(data_path);

        var lines = File.ReadLines(dataFileName);
        int currentline = 0;
        foreach (string line in lines)
        {
            currentline++;
            if (currentline == 1)
            {
                var columnnames = line.Split(';');
                var columnIndex = 0;

                foreach (string columnname in columnnames)
                {
                    DataMapping dataMapping;
                    if (config.Datamappings.TryGetValue(columnname, out dataMapping))
                    {
                        dataMapping.ColumnIndex = columnIndex;
                        config.Datamappings[columnname] = dataMapping;
                    }


                    columnIndex++;
                }

                continue;
            }
            else
            {
                var transaction = new Transaction();
                var transactionData = line.Split(';');
                transaction.Date = DateTime.Parse(transactionData[config.Datamappings["date"].ColumnIndex]);
                transaction.Value = decimal.Parse(transactionData[config.Datamappings["value"].ColumnIndex]);
                transaction.Subject = (string) transactionData[config.Datamappings["subject"].ColumnIndex];
                transaction.Receiver = (string) transactionData[config.Datamappings["receiver"].ColumnIndex];
                transaction.Description = (string) transactionData[config.Datamappings["description"].ColumnIndex];

                
                _transactions.Add(transaction);
            }
        }

        Console.WriteLine("Transactions: ");
        _transactions.ForEach(t => Console.WriteLine(t.ToString()));

        Console.WriteLine("Sorting with value mappings: ");
        var mappedTransactions = new Dictionary<string, List<Transaction>>();

        foreach(var transaction in _transactions)
        {
            var matchedMapping = config.ValueMappings.FirstOrDefault(m => transaction.ToString().Contains(m.Keyword));
            if(matchedMapping == null) continue;
            
            if(!mappedTransactions.ContainsKey(matchedMapping.Category))
            {
                mappedTransactions.Add(matchedMapping.Category, new List<Transaction>());
            }

            var categorieList = mappedTransactions.GetValueOrDefault(matchedMapping.Category);
            if(categorieList != null)
            {
                categorieList.Add(transaction);
            }
        }

        Console.WriteLine("Sorted with value Mappings:");

        foreach(var account in mappedTransactions)
        {
            Console.WriteLine("Transactions for " + account.Key + " :");
            decimal accountSum = new decimal(0);
            var accountTransactions = mappedTransactions[account.Key];
            foreach(var accountTransaction in accountTransactions)
            {
                accountSum += accountTransaction.Value;
                Console.WriteLine(accountTransaction.ToString());
            }
            
            Console.WriteLine("Account Sum: " + accountSum);
            Console.WriteLine("---");
        }


    }

    public class Config
    {
        //
        // Path to Configfile 
        // eg home/user/Documents to find home/user/Documents/CENTSATIONAL_CONFIG.csv
        public string ConfigfilePath;
        //
        // Path to Datafiles
        // Datafilepath | File1, File2.. FileN | -
        // eg home/user/Documents/
        public List<string> Datafilenames;
        // 
        // Each Line from Datafile is being converted into one Transaction,
        // Mappings for data Columns in Datafile(s):
        // 
        // datamapping | Date | Datecolumn
        // datamapping | Receiver | Receivercolumn
        // datamapping | Subject | SubjectColumn
        // datamapping | Description | DescriptionColumn
        // datamapping | Value | ValueColumn
        public IDictionary<string, DataMapping> Datamappings;
        //
        // Value Mappings (Value Rules?)
        // Each Transaction is being sorted into one Category by Keyword Matching
        // Matchings have to be provided within the configfile in the following form: 
        // Category | Keyword | Operation
        // eg.:
        // valuemapping | Staple Foods | Kölsch | Contains

        public List<ValueMapping> ValueMappings; // @todo better naming ?!

        public Config() { }
        public Config(string path)
        {
            ConfigfilePath = path;
            Datafilenames = new List<string>();
            Datamappings = new Dictionary<string, DataMapping>();
            ValueMappings = new List<ValueMapping>();
        }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(ConfigfilePath) &&
                    Datafilenames.Any() &&
                    Datamappings.Any() &&
                    ValueMappings.Any();
        }

        public Config FromPath(string path)
        {
            var c = new Config(path);

            var lines = File.ReadLines(path);
            int currentline = 0;
            foreach (string line in lines)
            {
                var splits = line.Split(';');
                var linetopic = splits[0].ToLower();

                if (linetopic.Equals("datafilenames"))
                {
                    c.Datafilenames = splits[1].Split(',').ToList();
                    continue;
                }
                else if (linetopic.Equals("datamapping"))
                {
                    string property = splits[1];
                    string column = splits[2];

                    Datamappings.Add(column, new DataMapping(property, column));
                }
                else if (linetopic.Equals("valuemapping"))
                {
                    string category = splits[1];
                    string keyword = splits[2];
                    string operation = splits[3];

                    ValueMappings.Add(new ValueMapping(category, keyword, operation));
                }

                currentline++;
            }

            return c;
        }
    }

    public class Transaction
    {
        public DateTime Date;
        public string Receiver;
        public string Subject;
        public string Description;
        public decimal Value;

        public override string ToString()
        {
            return string.Format("Date: {0}, Value: {1}, Receiver: {2}, Subject: {3}, Description: {4}", Date, Value, Receiver, Subject, Description); 
        }

    }

    public class DataMapping
    {
        // The property to be Mapped from datafile to Transaction
        public string Property;
        // The Name of the column which contains the üroperties data 
        public string ColumnName;
        // Index of the column which contains the properties data
        public int ColumnIndex;

        public DataMapping(string property, string columnname, int columnindex = -1)
        {
            Property = property;
            ColumnName = columnname;
            ColumnIndex = columnindex;
        }
    }

    public class ValueMapping
    {
        // @todo better naming!?
        public string Category = "";
        public string Keyword = "";
        public string Operation = "";

        public List<Transaction> Transactions = new();

        public ValueMapping(string category, string keyword, string operation)
        {
            Category = category;
            Keyword = keyword;
            Operation = operation;
        }
    }
}


