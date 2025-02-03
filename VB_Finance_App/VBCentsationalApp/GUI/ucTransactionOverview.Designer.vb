<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTransactionOverview
	Inherits System.Windows.Forms.UserControl

	'UserControl overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		dgvTransactions = New DataGridView()
		cmbSearchRepository = New ComboBox()
		tbSearchTransaction = New TextBox()
		btnSearch = New Button()
		btnCancel = New Button()
		CType(dgvTransactions, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' dgvTransactions
		' 
		dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgvTransactions.Location = New Point(19, 66)
		dgvTransactions.Name = "dgvTransactions"
		dgvTransactions.Size = New Size(643, 385)
		dgvTransactions.TabIndex = 6
		' 
		' cmbSearchRepository
		' 
		cmbSearchRepository.DropDownWidth = 100
		cmbSearchRepository.Items.AddRange(New Object() {RepositoryType.Csv, RepositoryType.LocalTestData, RepositoryType.Sql})
		cmbSearchRepository.Location = New Point(19, 25)
		cmbSearchRepository.Name = "cmbSearchRepository"
		cmbSearchRepository.Size = New Size(100, 23)
		cmbSearchRepository.TabIndex = 2
		' 
		' tbSearchTransaction
		' 
		tbSearchTransaction.Location = New Point(125, 26)
		tbSearchTransaction.Name = "tbSearchTransaction"
		tbSearchTransaction.Size = New Size(400, 23)
		tbSearchTransaction.TabIndex = 3
		' 
		' btnSearch
		' 
		btnSearch.Location = New Point(537, 25)
		btnSearch.Name = "btnSearch"
		btnSearch.Size = New Size(100, 23)
		btnSearch.TabIndex = 4
		btnSearch.Text = "Suchen"
		' 
		' btnCancel
		' 
		btnCancel.Location = New Point(642, 25)
		btnCancel.Name = "btnCancel"
		btnCancel.Size = New Size(23, 23)
		btnCancel.TabIndex = 5
		btnCancel.Text = "X"
		' 
		' ucTransactionOverview
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		Controls.Add(dgvTransactions)
		Controls.Add(cmbSearchRepository)
		Controls.Add(tbSearchTransaction)
		Controls.Add(btnSearch)
		Controls.Add(btnCancel)
		Name = "ucTransactionOverview"
		Size = New Size(689, 485)
		CType(dgvTransactions, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Public WithEvents dgvTransactions As DataGridView
	Public WithEvents cmbSearchRepository As ComboBox
	Public WithEvents tbSearchTransaction As TextBox
	Public WithEvents btnSearch As Button
	Public WithEvents btnCancel As Button

End Class
