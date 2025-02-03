<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		TabControl1 = New TabControl()
		tbBudgetOverview = New TabPage()
		tbTransactionOverview = New TabPage()
		tbBudgetsConfiguration = New TabPage()
		tbDataImport = New TabPage()
		TabControl1.SuspendLayout()
		SuspendLayout()
		' 
		' TabControl1
		' 
		TabControl1.Controls.Add(tbBudgetOverview)
		TabControl1.Controls.Add(tbTransactionOverview)
		TabControl1.Controls.Add(tbBudgetsConfiguration)
		TabControl1.Controls.Add(tbDataImport)
		TabControl1.Location = New Point(3, 3)
		TabControl1.Name = "TabControl1"
		TabControl1.SelectedIndex = 0
		TabControl1.Size = New Size(833, 542)
		TabControl1.TabIndex = 0
		' 
		' TabPage1
		' 
		tbBudgetOverview.Location = New Point(4, 24)
		tbBudgetOverview.Name = "TabPage1"
		tbBudgetOverview.Padding = New Padding(3)
		tbBudgetOverview.Size = New Size(825, 514)
		tbBudgetOverview.TabIndex = 0
		tbBudgetOverview.Text = "Übersicht"
		tbBudgetOverview.UseVisualStyleBackColor = True
		' 
		' TabPage2
		' 
		tbTransactionOverview.Location = New Point(4, 24)
		tbTransactionOverview.Name = "TabPage2"
		tbTransactionOverview.Padding = New Padding(3)
		tbTransactionOverview.Size = New Size(644, 407)
		tbTransactionOverview.TabIndex = 1
		tbTransactionOverview.Text = "Transaktionen"
		tbTransactionOverview.UseVisualStyleBackColor = True
		' 
		' TabPage3
		' 
		tbBudgetsConfiguration.Location = New Point(4, 24)
		tbBudgetsConfiguration.Name = "TabPage3"
		tbBudgetsConfiguration.Padding = New Padding(3)
		tbBudgetsConfiguration.Size = New Size(644, 407)
		tbBudgetsConfiguration.TabIndex = 2
		tbBudgetsConfiguration.Text = "Budgets"
		tbBudgetsConfiguration.UseVisualStyleBackColor = True
		' 
		' TabPage4
		' 
		tbDataImport.Location = New Point(4, 24)
		tbDataImport.Name = "TabPage4"
		tbDataImport.Padding = New Padding(3)
		tbDataImport.Size = New Size(644, 407)
		tbDataImport.TabIndex = 3
		tbDataImport.Text = "Import"
		tbDataImport.UseVisualStyleBackColor = True
		' 
		' Form1
		' 
		AutoScaleDimensions = New SizeF(7.0F, 15.0F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(838, 547)
		Controls.Add(TabControl1)
		Name = "Form1"
		Text = "Form1"
		TabControl1.ResumeLayout(False)
		ResumeLayout(False)

	End Sub

	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents tbBudgetOverview As TabPage
	Friend WithEvents tbTransactionOverview As TabPage
	Friend WithEvents tbBudgetsConfiguration As TabPage
	Friend WithEvents tbDataImport As TabPage

End Class



