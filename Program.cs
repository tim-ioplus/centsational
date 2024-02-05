using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace HelloWorld;

class Program
{
    private const string DOCPATHKEY = "CENTSATIONAL_INPUT_PATH";

    private static string DOCPATHKEY2 = "CENTSATIONAL_CONFIG_PATH";

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        string document_path = Environment.GetEnvironmentVariable(DOCPATHKEY);
        string config_path = Environment.GetEnvironmentVariable(DOCPATHKEY2);
        
        if(string.IsNullOrEmpty(document_path))
        {
            Console.WriteLine("Please provide the path to the directory from where toread your Document.");
            document_path = Console.ReadLine();
        }
        
        if(string.IsNullOrEmpty(config_path))
        {
            Console.WriteLine("Please provide the path to the directory where your Configuration resides.");
            config_path = Console.ReadLine();
        }

        if(string.IsNullOrEmpty(document_path)) return;
        if(string.IsNullOrEmpty(config_path)) return;

        var configfilename = Path.GetFileName(config_path);
        Config? config = null;
        if(!string.IsNullOrEmpty(configfilename))
        {
             config = new Config().FromPath(configfilename);
        }
        else
        {
            Console.WriteLine("No Configuraiton found. exit.");
            return;
            // or maybe use some Default configuration?
        }

        if(config == null)
        {
            Console.WriteLine("No configuraiton provided. exit.");
            return;
        }
        if(!config.Validate())
        {
            Console.Write("Configuration data is invalid. exit.");
            return;
        }

        var dataFileName = Path.GetFileName(document_path);

        var lines = File.ReadLines(dataFileName);
        int currentline = 0;
        foreach(string line in lines)
        {
            currentline++;
            if(currentline == 1)
            {
                var columnnames = line.Split(';');
                var columnIndex = 0;

                foreach(string columnname in columnnames)
                {
                    DataMapping dataMapping;
                    if(config.Datamappings.TryGetValue(columnname, out dataMapping))
                    {
                        dataMapping.ColumnIndex = columnIndex;
                    }

                    
                    columnIndex++;
                }

                continue;
            }

            var splits = line.Split(';');
        }

    }

    public class Config 
    {
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
        // Value Mappings
        // Each Transaction is being sorted into one Category by Keyword Matching
        // Matchings have to be provided within the configfile in the following form: 
        // Category | Keyword | Operation
        // eg.:
        // valuemapping | Staple Foods | Kölsch | Contains

        public List<ValueMapping> ValueMappings; // @todo better naming ?!
        
        public Config(){}
        public Config(string path)
        {
            ConfigfilePath = path;
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

        public Config FromPath(string path)
        {
            var c = new Config(path);

            var lines = File.ReadLines(path);
            int currentline = 0;
            foreach(string line in lines)
            {
                var splits = line.Split(';');
                var linetopic = splits[0].ToLower();

                if(linetopic.Equals("datafilenames"))
                {
                    c.Datafilenames = splits[1].Split(',').ToList();
                    continue;
                }
                else if(linetopic.Equals("datamapping"))
                {
                    string property = splits[1];
                    string column = splits[2];

                    Datamappings.Add(column, new DataMapping(property, column));
                }
                else if(linetopic.Equals("valuemapping"))
                {
                    string category = splits[1];
                    string keyword = splits[2];
                    string operation = splits[3];

                    ValueMappings.Add(new ValueMapping(category, keyword, operation));
                }
                
                currentline++;
            }

            return c;
        }
    }

    public class Transaction
    {
        public DateAndTime Date;
        public string Receiver;
        public string Subject;
        public string Description;
        public Decimal Value;

    }

    public class DataMapping
    {
        // The property to be Mapped from datafile to Transaction
        public string Property;
        // The Name of the column which contains the üroperties data 
        public string ColumnName;
        // Index of the column which contains the properties data
        public int ColumnIndex;

        public DataMapping(string property, string columnname, int columnindex = -1)
        {
            Property = property;
            ColumnName = columnname;
            ColumnIndex = columnindex;
        }
    }

    public class ValueMapping
    {
        // @todo better naming!?
        public string Category = "";
        public string Keyword = "";
        public string Operation = "";

        public ValueMapping(string category, string keyword, string operation)
        {
            Category = category;
            Keyword = keyword;
            Operation = operation;
        }
    }
} 


