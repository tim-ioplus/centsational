<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBudgetOverview
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
		lblBudgetOverviewH1 = New Label()
		pnlBudgetDetails = New Panel()
		SuspendLayout()
		' 
		' lblBudgetOverviewH1
		' 
		lblBudgetOverviewH1.AutoSize = True
		lblBudgetOverviewH1.Location = New Point(7, 8)
		lblBudgetOverviewH1.Name = "lblBudgetOverviewH1"
		lblBudgetOverviewH1.Size = New Size(98, 15)
		lblBudgetOverviewH1.TabIndex = 0
		lblBudgetOverviewH1.Text = "Budget Übersicht"
		' 
		' pnlBudgetDetails
		' 
		pnlBudgetDetails.Location = New Point(13, 42)
		pnlBudgetDetails.Name = "pnlBudgetDetails"
		pnlBudgetDetails.Size = New Size(612, 366)
		pnlBudgetDetails.TabIndex = 1
		' 
		' ucBudgetOverview
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		Controls.Add(pnlBudgetDetails)
		Controls.Add(lblBudgetOverviewH1)
		Name = "ucBudgetOverview"
		Size = New Size(663, 420)
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lblBudgetOverviewH1 As Label
	Friend WithEvents pnlBudgetDetails As Panel

End Class
