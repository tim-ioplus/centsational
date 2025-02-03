Public Class Form1



	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()


	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim ucTransactionOverview As New ucTransactionOverview()
		ucTransactionOverview.Dock = DockStyle.Fill

		Dim ucBudgetOverview As New ucBudgetOverview()
		ucBudgetOverview.Dock = DockStyle.Fill

		Dim ucBudgetsConfiguration As New ucBudgetsConfiguration()
		ucBudgetsConfiguration.Dock = DockStyle.Fill

		Dim ucImportConfiguration As New ucImportConfiguration()
		ucBudgetsConfiguration.Dock = DockStyle.Fill

		tbBudgetOverview.Controls.Add(ucBudgetOverview)
		tbTransactionOverview.Controls.Add(ucTransactionOverview)
		tbBudgetsConfiguration.Controls.Add(ucBudgetsConfiguration)
		tbDataImport.Controls.Add(ucImportConfiguration)
	End Sub

End Class
