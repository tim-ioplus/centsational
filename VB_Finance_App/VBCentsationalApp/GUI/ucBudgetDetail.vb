Public Class ucBudgetDetail
	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

	End Sub

	Public Sub SetBudget(name As String, amountSpend As Decimal, amountTotal As Decimal)
		Me.lblBudgetName.Text = name
		Me.lblBudgetSummary.Text = String.Format("{0} € von {1} € verbraucht", amountSpend, amountTotal)
		Dim value As Integer = (amountSpend / amountTotal * 100)
		Me.pbBudgetUsed.Value = value

		Me.Update()
	End Sub


End Class
