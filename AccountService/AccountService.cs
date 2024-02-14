using System;
using Account.Domain;

namespace Account.Service;

public class AccountService
{
    public Config Configuration;
    public List<Transaction> Transactions;

    public Dictionary<string, List<Transaction>> Accounts;

    public AccountService(){}

    /// <summary>
    /// Mapping the readed Transactions into account using the given ruleset
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public Dictionary<string, List<Transaction>> MapTransactions()
    {
        Accounts = new Dictionary<string, List<Transaction>>();

        foreach(var transaction in Transactions)
        {
            var matchedMapping = Configuration.ValueMappings.FirstOrDefault(m => transaction.ToString().Contains(m.Keyword));
            if(matchedMapping == null) continue;
            
            if(!Accounts.ContainsKey(matchedMapping.Category))
            {
                Accounts.Add(matchedMapping.Category, new List<Transaction>());
            }

            var categorieList = Accounts.GetValueOrDefault(matchedMapping.Category);
            if(categorieList != null)
            {
                categorieList.Add(transaction);
            }
        }

        return Accounts;
    }

    public void SumAccounts(Dictionary<string, List<Transaction>> accounts)
    {
        foreach(var account in accounts)
        {
            SumAccount(account.Value);
        }
    }

    public decimal SumAccount(List<Transaction> transactions)
    {
        decimal accountSum = new decimal(0);
        
        foreach(var accountTransaction in transactions)
        {
            accountSum += accountTransaction.Value;
        }

        return accountSum;
    }

    public Config ReadConfiguration(string configfilePath)
    {
        Config? config = null;
        if (File.Exists(configfilePath))
        {
            config = new Config(configfilePath);
            config.ReadFromPath();
        }
        else
        {
            Console.WriteLine("No Configuraiton found. exit.");
            return null;
            // or maybe use some Default configuration?
        }

        if (config == null)
        {
            Console.WriteLine("No configuraiton provided. exit.");
            return null;
        }
        if (!config.Validate())
        {
            Console.Write("Configuration data is invalid. exit.");
            return null;
        }

        return config;
    }

    public object ReadTransactions(Config config, string data_path)
    {
        var dataFileName = config.Datafilenames.FirstOrDefault();

        if(!File.Exists(dataFileName))
        {
            throw new FileNotFoundException("Transaction Data File " + dataFileName + " not found.");
        }

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

                
                Transactions.Add(transaction);
            }
        }

        return Transactions;
    }
}