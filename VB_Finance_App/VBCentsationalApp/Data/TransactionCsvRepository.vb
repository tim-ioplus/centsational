Imports System.IO
Imports Domain

Public Class TransactionCsvRepository
	Implements ITransactionRepository

	Public Transactions As List(Of Transaction)

	Sub New()
		Transactions = New List(Of Transaction)
		Hydrate()
	End Sub

	Private Sub Hydrate()
		' dateipfad
		Dim path As String = "C:\Users\T14\Documents\GitHub\PFA\Data\data.CSV"

		' datei existriert
		Dim linecount As Integer = 0
		If File.Exists(path) Then
			For Each line As String In File.ReadLines(path)
				If linecount > 0 Then
					Dim transaction = New Transaction().FromCsv(line)

					If Not transaction Is Nothing Then
						Transactions.Add(transaction)
					End If
				End If

				linecount += 1
			Next

		End If
		' datei laden
		' für jede Zeile
		' csv Zeile zu Object laden
		' objekt in Liste speichern
	End Sub


	Public Function List() As List(Of Transaction) Implements ITransactionRepository.List
		Return Transactions.ToList
	End Function

	Public Function Find(searchText As String) As List(Of Transaction) Implements ITransactionRepository.Find
		Dim lowerSearchText As String = searchText.ToLower
		Dim result = From t In Transactions Where t.ToString().ToLower().Contains(lowerSearchText)

		Return result.ToList

	End Function
End Class


