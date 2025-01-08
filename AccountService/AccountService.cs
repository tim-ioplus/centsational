using Domain;
using System;

namespace Services;

public class AccountService
{
	public Configuration Configuration;
	public List<Transaction> Transactions;

	public Dictionary<string, List<Transaction>> Accounts;

	public AccountService()
	{
		Configuration = new Configuration("", "");
		Transactions = [];
		Accounts = [];
	}

	/// <summary>
	/// Mapping the readed Transactions into account using the given ruleset
	/// </summary>
	/// <param name="configuration"></param>
	/// <returns></returns>
	public Dictionary<string, List<Transaction>> MapTransactions()
	{
		Accounts = new Dictionary<string, List<Transaction>>();

		foreach (var transaction in Transactions)
		{
			var matchedMapping = Configuration.ValueMappings.FirstOrDefault(m => transaction.ToString().Contains(m.Keyword));
			if (matchedMapping == null) continue;

			if (!Accounts.ContainsKey(matchedMapping.Category))
			{
				Accounts.Add(matchedMapping.Category, new List<Transaction>());
			}

			var categorieList = Accounts.GetValueOrDefault(matchedMapping.Category);
			if (categorieList != null)
			{
				categorieList.Add(transaction);
			}
		}

		return Accounts;
	}

	public void SumAccounts(Dictionary<string, List<Transaction>> accounts, bool verbose = true)
	{
		foreach (var account in accounts)
		{
			var accountSum = SumAccount(account.Value);
			if (verbose) Console.WriteLine("Account: " + account.Key + " Sum: " + accountSum);
		}
	}

	public decimal SumAccount(List<Transaction> transactions)
	{
		decimal accountSum = new decimal(0);

		foreach (var accountTransaction in transactions)
		{
			accountSum += accountTransaction.Value;
		}

		return accountSum;
	}


	public object ReadTransactions(Configuration configuration)
	{
		var dataFileName = configuration.DirectoryPath + "/" + configuration.Datafilenames.FirstOrDefault();

		if (!File.Exists(dataFileName))
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
					DataMapping? dataMapping;
					if (configuration.Datamappings.TryGetValue(columnname, out dataMapping))
					{
						dataMapping.ColumnIndex = columnIndex;
						configuration.Datamappings[columnname] = dataMapping;
					}

					columnIndex++;
				}

				continue;
			}
			else
			{
				var transaction = new Transaction();
				var transactionData = line.Split(';');

				if (configuration.Datamappings.TryGetValue("Date", out var dateMapping))
				{
					if (DateTime.TryParse(transactionData[dateMapping.ColumnIndex], out var transactionDate))
					{
						transaction.Date = transactionDate;
					}
				}

				if (configuration.Datamappings.TryGetValue("Value", out var valueMapping))
				{
					if (decimal.TryParse(transactionData[valueMapping.ColumnIndex], out decimal transactionValue))
					{
						transaction.Value = transactionValue;
					}
				}

				if (configuration.Datamappings.TryGetValue("Subject", out var subjectMapping))
				{
					var transactionSubject = transactionData[subjectMapping.ColumnIndex];
					transaction.Subject = transactionSubject;
				}

				if (configuration.Datamappings.TryGetValue("Receiver", out var receiverMapping))
				{
					var transactionReceiver = transactionData[receiverMapping.ColumnIndex];
					transaction.Receiver = transactionReceiver;
				}

				if (configuration.Datamappings.TryGetValue("Description", out var descriptionMapping))
				{
					var transactionSubject = transactionData[descriptionMapping.ColumnIndex];
					transaction.Description = transactionSubject;
				}

				Transactions.Add(transaction);
			}
		}

		return Transactions;
	}
}