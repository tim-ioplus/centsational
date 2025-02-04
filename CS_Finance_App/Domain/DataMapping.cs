namespace CSDomain;

public class DataMapping
{
	// The property to be Mapped from datafile to Transaction
	// To be filled on reading the config file
	public string Property;
	// Index of the column which contains the properties data
	// To be filled on reading the config file
	public int ColumnIndex;

	// The Name of the column which contains the properties data
	// To be filled on reading the data file 
	public string ColumnName;

	public DataMapping(string property, int columnindex = -1, string columnname = "")
	{
		Property = property;
		ColumnIndex = columnindex;
		ColumnName = columnname;
	}
}
