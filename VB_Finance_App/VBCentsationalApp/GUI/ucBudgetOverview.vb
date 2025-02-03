Imports System.Runtime.CompilerServices

Public Class ucBudgetOverview

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

	End Sub

	Private Sub ucBudgetOverview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.SuspendLayout()

		Dim bdgtDetail1 = New ucBudgetDetail
		bdgtDetail1.Location = New Point(0, 0)
		Dim ucHeight = bdgtDetail1.Height
		bdgtDetail1.SetBudget("Wohnen", 1051.75, 1550.0)

		Dim bdgtDetail2 = New ucBudgetDetail
		bdgtDetail2.Location = New Point(0, ucHeight)
		bdgtDetail2.SetBudget("Lebenmittel & Drogerie", 925.0, 1000.0)

		Dim bdgtDetail3 = New ucBudgetDetail
		bdgtDetail3.Location = New Point(0, 2 * ucHeight)
		bdgtDetail3.SetBudget("Einkaufen", 285.99, 400.0)

		Me.pnlBudgetDetails.Controls.Add(bdgtDetail1)
		Me.pnlBudgetDetails.Controls.Add(bdgtDetail2)
		Me.pnlBudgetDetails.Controls.Add(bdgtDetail3)

		Me.ResumeLayout()
		Me.Update()

	End Sub
End Class
