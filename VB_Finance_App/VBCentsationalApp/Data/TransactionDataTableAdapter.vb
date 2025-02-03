Imports Domain

Public Class TransactionDataTableAdapter
	Implements IDataTableAdapter

	Private _transactionRepository As ITransactionRepository
	Private _resultDataTable As DataTable

	Sub New(ByVal repositoryType As RepositoryType)
		If repositoryType = RepositoryType.LocalTestData Then
			_transactionRepository = New TransactionLocalTestDataRespository
		ElseIf repositoryType = RepositoryType.Csv Then
			_transactionRepository = New TransactionCsvRepository
		ElseIf repositoryType = RepositoryType.Sql Then
			_transactionRepository = New TransactionSqlRepository
		End If

		_resultDataTable = New DataTable

		' add columns
		_resultDataTable.Columns.Add("Nummer", GetType(String))
		_resultDataTable.Columns.Add("Empfänger Name", GetType(String))
		_resultDataTable.Columns.Add("Empfänger Iban", GetType(String))
		_resultDataTable.Columns.Add("Datum", GetType(DateTime))
		_resultDataTable.Columns.Add("Betreff", GetType(String))
		_resultDataTable.Columns.Add("Betrag", GetType(Decimal))
	End Sub

	Public Function List() As DataTable Implements IDataTableAdapter.List
		Dim results = _transactionRepository.List
		Dim DataTable = FillTable(results)

		Return DataTable
	End Function

	Public Function Find(ByVal searchText As String) As DataTable Implements IDataTableAdapter.Find
		Dim results = _transactionRepository.Find(searchText)
		Dim DataTable = FillTable(results)

		Return DataTable
	End Function

	Public Function FillTable(results As List(Of Transaction)) As DataTable Implements IDataTableAdapter.FillTable

		_resultDataTable.Rows.Clear()

		For Each result In results
			_resultDataTable.Rows.Add(result.Id, result.ReceiverName, result.ReceiverIban, result.TransactionDate, result.Topic, result.Amount)
		Next

		Return _resultDataTable

	End Function
End Class
