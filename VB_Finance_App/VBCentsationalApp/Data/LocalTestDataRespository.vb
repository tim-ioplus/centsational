Imports Domain
Imports Domain.Domain

Friend Class TransactionLocalTestDataRespository
	Implements ITransactionRepository

	Public Transactions As List(Of Transaction)

	Sub New()
		Transactions = New List(Of Transaction)

		Hydrate()
	End Sub

	Private Sub Hydrate()
		Transactions = New List(Of Transaction) From {
			New Transaction("111", "Jupp", "DE661234578", New Date(2025, 1, 1), "Koelsch", 11.11),
			New Transaction("222", "Irmela", "NL123456789", New Date(2025, 1, 2), "Halve Hahn", 22.11),
			New Transaction("333", "Urmel", "FR987654112", New Date(2025, 1, 3), "Himmel un Ääd", 33.11)
		}
	End Sub

	Public Function List() As List(Of Transaction) Implements ITransactionRepository.List
		Return Transactions
	End Function

	Public Function Find(ByVal searchtext As String) As List(Of Transaction) Implements ITransactionRepository.Find
		Dim lowerSearchText As String = searchtext.ToLower
		Dim result = From t In Transactions Where t.ToString().ToLower().Contains(lowerSearchText)

		Return result

	End Function

End Class
