namespace Account.Domain;
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

        public Config() { }
        public Config(string path, bool verbose = true)
        {
            ConfigfilePath = path;
            Datafilenames = new List<string>();
            Datamappings = new Dictionary<string, DataMapping>();
            ValueMappings = new List<ValueMapping>();
            Verbose = true;
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
            foreach (string line in lines)
            {
                var splits = line.Split(';');
                var linetopic = splits[0].ToLower();

                if (linetopic.Equals("datafilenames"))
                {
                    c.Datafilenames = splits[1].Split(',').ToList();
                    continue;
                }
                else if (linetopic.Equals("datamapping"))
                {
                    string property = splits[1];
                    string column = splits[2];

                    Datamappings.Add(column, new DataMapping(property, column));
                }
                else if (linetopic.Equals("valuemapping"))
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
        public DateTime Date;
        public string Receiver;
        public string Subject;
        public string Description;
        public decimal Value;

        public override string ToString()
        {
            return string.Format("Date: {0}, Value: {1}, Receiver: {2}, Subject: {3}, Description: {4}", Date, Value, Receiver, Subject, Description); 
        }

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

        public List<Transaction> Transactions = new();

        public ValueMapping(string category, string keyword, string operation)
        {
            Category = category;
            Keyword = keyword;
            Operation = operation;
        }
    }