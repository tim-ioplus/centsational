namespace CSDomain;
public class Configuration
{
	/// <summary>
	/// Base for Config and Data files
	/// </summary>
	public string DirectoryPath = "";
	//
	// Path to Configfile 
	// eg home/user/Documents to find home/user/Documents/CENTSATIONAL_CONFIG.csv
	public string ConfigfilePath;
	//
	// Path to Datafiles
	// Datafilepath | File1, File2.. FileN | -
	// eg home/user/Documents/
	public List<string> Datafilenames;
	// 
	// Each Line from Datafile is being converted into one Transaction,
	// Mappings for data Columns in Datafile(s):
	// 
	// datamapping | Date | Datecolumn
	// datamapping | Receiver | Receivercolumn
	// datamapping | Subject | SubjectColumn
	// datamapping | Description | DescriptionColumn
	// datamapping | Value | ValueColumn
	public IDictionary<string, DataMapping> Datamappings;
	//
	// Value Mappings (Value Rules?)
	// Each Transaction is being sorted into one Category by Keyword Matching
	// Matchings have to be provided within the configfile in the following form: 
	// Category | Keyword | Operation
	// eg.:
	// valuemapping | Staple Foods | Kölsch | Contains

	public List<ValueMapping> ValueMappings; // @todo better naming ?!

	/// <summary>
	/// Logging Verbosity. 
	/// + true: everything weill be logged
	/// + false: only Account Sums will be logged
	/// </summary>
	public bool Verbose;

	public Configuration(string path, string configFileName)
	{
		DirectoryPath = path;
		ConfigfilePath = Path.Combine(DirectoryPath, configFileName);

		Datafilenames = new List<string>();
		Datamappings = new Dictionary<string, DataMapping>();
		ValueMappings = new List<ValueMapping>();
	}

	public bool Validate()
	{
		return !string.IsNullOrEmpty(ConfigfilePath) &&
				Datafilenames.Any() &&
				Datamappings.Any() &&
				ValueMappings.Any();
	}
}
