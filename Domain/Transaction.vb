

Public Class Transaction
	Public Id As String
	Public ReceiverName As String
	Public ReceiverIban As String
	Public TransactionDate As Date
	Public Topic As String
	Public Amount As Decimal

	Public Sub New()

	End Sub

	Public Sub New(id As String, receiverName As String, receiverIban As String, effectivedate As Date, topic As String, amount As Decimal)
		Me.Id = id
		Me.ReceiverName = receiverName
		Me.ReceiverIban = receiverIban
		Me.TransactionDate = effectivedate
		Me.Topic = topic
		Me.Amount = amount
	End Sub

	Public Function FromCsv(ByVal csvline As String) As Transaction
		Dim splitted = csvline.Replace("""", "").Split(";")
		Dim transaction = New Transaction()

		transaction.Id = Guid.NewGuid().ToString
		transaction.ReceiverName = splitted(5).Replace("  ", "")
		transaction.ReceiverIban = splitted(6)

		Dim transactiondatetext = splitted(2)
		Dim transactiondate = DateTime.MinValue
		If DateTime.TryParse(transactiondatetext, transactiondate) Then
			transaction.TransactionDate = transactiondate
		End If

		transaction.Topic = splitted(4)

		Dim transactionamounttext = splitted(8).Replace("""", "")

		Dim transactionamount As Decimal = 0
		If Decimal.TryParse(transactionamounttext, transactionamount) Then
			transaction.Amount = transactionamount
		End If

		Return transaction
	End Function

	Public Overrides Function ToString() As String
		Return Me.Id + ", " + Me.ReceiverName + ", " + Me.ReceiverIban + ", " +
			Me.TransactionDate.ToString() + ", " + Me.Topic + ", " + Me.Amount.ToString()

	End Function

End Class
