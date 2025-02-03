<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucImportConfiguration
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
		Dim btnTestConnection As Button
		Dim btnSaveDatabaseConnection As Button
		btnImportData = New Button()
		tbDatafilePath = New TextBox()
		lblDatafilePath = New Label()
		tbConnectionSting = New TextBox()
		lblConnectionString = New Label()
		lblbImportConfiguration = New Label()
		btnTestConnection = New Button()
		btnSaveDatabaseConnection = New Button()
		SuspendLayout()
		' 
		' btnTestConnection
		' 
		btnTestConnection.Location = New Point(271, 72)
		btnTestConnection.Name = "btnTestConnection"
		btnTestConnection.Size = New Size(114, 23)
		btnTestConnection.TabIndex = 15
		btnTestConnection.Text = "Verbindung testen"
		btnTestConnection.UseVisualStyleBackColor = True
		' 
		' btnSaveDatabaseConnection
		' 
		btnSaveDatabaseConnection.Location = New Point(391, 72)
		btnSaveDatabaseConnection.Name = "btnSaveDatabaseConnection"
		btnSaveDatabaseConnection.Size = New Size(108, 23)
		btnSaveDatabaseConnection.TabIndex = 14
		btnSaveDatabaseConnection.Text = "Speichern"
		btnSaveDatabaseConnection.UseVisualStyleBackColor = True
		' 
		' btnImportData
		' 
		btnImportData.Location = New Point(369, 140)
		btnImportData.Name = "btnImportData"
		btnImportData.Size = New Size(130, 23)
		btnImportData.TabIndex = 13
		btnImportData.Text = "Daten importieren"
		btnImportData.UseVisualStyleBackColor = True
		' 
		' tbDatafilePath
		' 
		tbDatafilePath.Location = New Point(102, 111)
		tbDatafilePath.Name = "tbDatafilePath"
		tbDatafilePath.Size = New Size(397, 23)
		tbDatafilePath.TabIndex = 12
		' 
		' lblDatafilePath
		' 
		lblDatafilePath.AutoSize = True
		lblDatafilePath.Location = New Point(3, 115)
		lblDatafilePath.Name = "lblDatafilePath"
		lblDatafilePath.Size = New Size(88, 15)
		lblDatafilePath.TabIndex = 11
		lblDatafilePath.Text = "Datendateipfad"
		' 
		' tbConnectionSting
		' 
		tbConnectionSting.Location = New Point(104, 43)
		tbConnectionSting.Name = "tbConnectionSting"
		tbConnectionSting.Size = New Size(397, 23)
		tbConnectionSting.TabIndex = 10
		' 
		' lblConnectionString
		' 
		lblConnectionString.AutoSize = True
		lblConnectionString.Location = New Point(3, 46)
		lblConnectionString.Name = "lblConnectionString"
		lblConnectionString.Size = New Size(64, 15)
		lblConnectionString.TabIndex = 9
		lblConnectionString.Text = "Datenbank"
		' 
		' lblbImportConfiguration
		' 
		lblbImportConfiguration.AutoSize = True
		lblbImportConfiguration.Location = New Point(3, 0)
		lblbImportConfiguration.Name = "lblbImportConfiguration"
		lblbImportConfiguration.Size = New Size(74, 15)
		lblbImportConfiguration.TabIndex = 8
		lblbImportConfiguration.Text = "Datenimport"
		' 
		' ucImportConfiguration
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		Controls.Add(btnTestConnection)
		Controls.Add(btnSaveDatabaseConnection)
		Controls.Add(btnImportData)
		Controls.Add(tbDatafilePath)
		Controls.Add(lblDatafilePath)
		Controls.Add(tbConnectionSting)
		Controls.Add(lblConnectionString)
		Controls.Add(lblbImportConfiguration)
		Name = "ucImportConfiguration"
		Size = New Size(606, 286)
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents btnImportData As Button
	Friend WithEvents tbDatafilePath As TextBox
	Friend WithEvents lblDatafilePath As Label
	Friend WithEvents tbConnectionSting As TextBox
	Friend WithEvents lblConnectionString As Label
	Friend WithEvents lblbImportConfiguration As Label

End Class
