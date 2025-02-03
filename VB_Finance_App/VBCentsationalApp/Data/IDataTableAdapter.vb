Imports Domain

Interface IDataTableAdapter
	Function List() As DataTable
	Function Find(ByVal searchText As String) As DataTable
	Function FillTable(ByVal results As List(Of Transaction)) As DataTable
End Interface
