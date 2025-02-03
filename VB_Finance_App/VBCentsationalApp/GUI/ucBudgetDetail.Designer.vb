<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBudgetDetail
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
		lblBudgetName = New Label()
		lblBudgetSummary = New Label()
		pbBudgetUsed = New ProgressBar()
		SuspendLayout()
		' 
		' lblBudgetName
		' 
		lblBudgetName.AutoSize = True
		lblBudgetName.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
		lblBudgetName.Location = New Point(6, 6)
		lblBudgetName.Name = "lblBudgetName"
		lblBudgetName.Size = New Size(75, 15)
		lblBudgetName.TabIndex = 0
		lblBudgetName.Text = "Budgetname"
		' 
		' lblBudgetSummary
		' 
		lblBudgetSummary.AutoSize = True
		lblBudgetSummary.Location = New Point(6, 32)
		lblBudgetSummary.Name = "lblBudgetSummary"
		lblBudgetSummary.Size = New Size(0, 15)
		lblBudgetSummary.TabIndex = 1
		' 
		' pbBudgetUsed
		' 
		pbBudgetUsed.Location = New Point(6, 60)
		pbBudgetUsed.MarqueeAnimationSpeed = 0
		pbBudgetUsed.Name = "pbBudgetUsed"
		pbBudgetUsed.Size = New Size(374, 23)
		pbBudgetUsed.Step = 1
		pbBudgetUsed.TabIndex = 2
		pbBudgetUsed.Value = 50
		' 
		' ucBudgetDetail
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		Controls.Add(pbBudgetUsed)
		Controls.Add(lblBudgetSummary)
		Controls.Add(lblBudgetName)
		Name = "ucBudgetDetail"
		Size = New Size(441, 107)
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lblBudgetName As Label
	Friend WithEvents lblBudgetSummary As Label
	Friend WithEvents pbBudgetUsed As ProgressBar

End Class
