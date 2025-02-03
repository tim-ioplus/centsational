Imports Domain
Imports Microsoft.Data.SqlClient
Public Class TransactionSqlRepository
	Implements ITransactionRepository

	Private builder As SqlConnectionStringBuilder
	Private cmd As SqlCommand
	Private reader As SqlDataReader

	Sub New()

		builder = New SqlConnectionStringBuilder
		builder.DataSource = "(local)\SQLEXPRESS"
		builder.UserID = "reffappsu"
		builder.Password = "U72gm5pNAJXDtsM3"
		builder.InitialCatalog = "PFA"
		builder.TrustServerCertificate = True

	End Sub
	Public Function List() As List(Of Transaction) Implements ITransactionRepository.List

		Dim transactions = New List(Of Transaction)

		Using connection = New SqlConnection(builder.ConnectionString)
			AddHandler connection.StateChange, Sub(sender, e) Console.WriteLine($"State changed: {e.OriginalState} -> {e.CurrentState}")

			cmd = connection.CreateCommand
			cmd.CommandText = "Select [Beguenstigter_Zahlungspflichtiger], [Kontonummer_IBAN], [Valutadatum], [Verwendungszweck], [Betrag] from Transactions"

			connection.Open()
			reader = cmd.ExecuteReader

			Do While reader.Read
				Dim transaction = New Transaction
				transaction.Id = Guid.NewGuid.ToString
				transaction.ReceiverName = reader.GetString(0)
				transaction.ReceiverIban = reader.GetString(1)
				transaction.TransactionDate = reader.GetDateTime(2)
				transaction.Topic = reader.GetString(3)
				transaction.Amount = reader.GetDecimal(4)

				'Dim amountDecimal As Decimal = 0
				'Dim amounttext =
				'If Decimal.TryParse(amounttext.ToString, amountDecimal) Then
				'transaction.Amount = amountDecimal
				'End If

				transactions.Add(transaction)
			Loop

			reader.Close()
			connection.Close()

		End Using

		Return transactions

	End Function

	Public Function Find(searchText As String) As List(Of Transaction) Implements ITransactionRepository.Find
		Dim transactions = New List(Of Transaction)

		Using con = New SqlConnection(builder.ConnectionString)
			cmd = con.CreateCommand
			cmd.CommandText = "Select [Beguenstigter_Zahlungspflichtiger], [Kontonummer_IBAN], [Valutadatum], [Verwendungszweck], [Betrag] from Transactions " +
				"WHERE [Beguenstigter_Zahlungspflichtiger] LIKE @queryReceiverName " +
				"OR [Kontonummer_IBAN] LIKE @queryReceiverIban " +
				"OR [Valutadatum] LIKE @queryTransactionDate " +
				"OR [Verwendungszweck] LIKE @queryTopic " +
				"OR [Betrag] LIKE @queryAmount "

			Dim commandValue As String = "%" & searchText.ToLower & "%"
			cmd.Parameters.AddWithValue("@queryReceiverName", commandValue)
			cmd.Parameters.AddWithValue("@queryReceiverIban", commandValue)
			cmd.Parameters.AddWithValue("@queryTransactionDate", commandValue)
			cmd.Parameters.AddWithValue("@queryTopic", commandValue)
			cmd.Parameters.AddWithValue("@queryAmount", commandValue)

			con.Open()
			reader = cmd.ExecuteReader

			Do While reader.Read
				Dim transaction = New Transaction
				transaction.Id = Guid.NewGuid().ToString
				transaction.ReceiverName = reader.GetString(0)
				transaction.ReceiverIban = reader.GetString(1)
				transaction.TransactionDate = reader.GetDateTime(2)
				transaction.Topic = reader.GetString(3)
				transaction.Amount = reader.GetDecimal(4)

				transactions.Add(transaction)
			Loop

			reader.Close()
			con.Close()

		End Using

		Return transactions
	End Function
End Class
