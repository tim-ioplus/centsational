Public Class ucTransactionOverview
	Private _transactionDataTableAdapter As IDataTableAdapter
	Private _adapters As Dictionary(Of RepositoryType, IDataTableAdapter)
	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		AddHandler tbSearchTransaction.TextChanged, New EventHandler(AddressOf TbSearchTransaction_TextChanged)
		AddHandler cmbSearchRepository.SelectedIndexChanged, New EventHandler(AddressOf cbSearchTestRepository_SelectedIndexChanged)
		AddHandler btnSearch.Click, New EventHandler(AddressOf BtnSearch_Click)
		AddHandler btnCancel.Click, New EventHandler(AddressOf BtnCancel_Click)
		AddHandler Me.Load, New EventHandler(AddressOf Me_Load)

		_adapters = New Dictionary(Of RepositoryType, IDataTableAdapter)
		_adapters.Add(RepositoryType.LocalTestData, New TransactionDataTableAdapter(RepositoryType.LocalTestData))
		_adapters.Add(RepositoryType.Csv, New TransactionDataTableAdapter(RepositoryType.Csv))
		_adapters.Add(RepositoryType.Sql, New TransactionDataTableAdapter(RepositoryType.Sql))

	End Sub

	Private Sub Me_Load(sender As Object, e As EventArgs)
		Me.cmbSearchRepository.SelectedItem = RepositoryType.Sql
	End Sub

	Private Sub Find()

		Dim results As DataTable = _transactionDataTableAdapter.Find(tbSearchTransaction.Text)
		dgvTransactions.DataSource = results

	End Sub

	Private Sub List()

		Dim results As DataTable = _transactionDataTableAdapter.List
		dgvTransactions.DataSource = results


	End Sub

	Private Sub TbSearchTransaction_TextChanged(sender As Object, e As EventArgs)
		Return

		If tbSearchTransaction.Text.Replace(" ", "").Length = 0 Then
			'List()
		Else
			'Find()
		End If

	End Sub


	Private Sub cbSearchTestRepository_SelectedIndexChanged(sender As Object, e As EventArgs)
		Dim cmbSearchRepo As ComboBox = sender
		_transactionDataTableAdapter = _adapters(cmbSearchRepo.SelectedItem)

		If tbSearchTransaction.Text.Length > 0 Then
			Find()
		Else
			List()
		End If

	End Sub

	Private Sub BtnSearch_Click(sender As Object, e As EventArgs)
		Find()
	End Sub

	Private Sub BtnCancel_Click(sender As Object, e As EventArgs)

		tbSearchTransaction.Text = ""
		List()

	End Sub

End Class
