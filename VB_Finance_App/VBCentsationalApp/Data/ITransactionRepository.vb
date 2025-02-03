Imports Domain

Interface ITransactionRepository
	Function List() As List(Of Transaction)
	Function Find(ByVal seachText As String) As List(Of Transaction)
End Interface