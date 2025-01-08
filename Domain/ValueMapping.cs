namespace Domain;

public class ValueMapping
    {
        // @todo better naming!?
        public string Category = "";
        public string Keyword = "";
        public string Operation = "";

        public List<Transaction> Transactions = [];

        public ValueMapping(string category, string keyword, string operation)
        {
            Category = category;
            Keyword = keyword;
            Operation = operation;
        }
    }