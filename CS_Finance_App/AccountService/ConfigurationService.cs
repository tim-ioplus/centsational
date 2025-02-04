using CSDomain;

namespace Services;
public class ConfigurationService
{
	public Configuration ReadFromPath(string path, string configFileName)
	{
		var configuration = new Configuration(path, configFileName);

		if (!File.Exists(configuration.ConfigfilePath))
		{
			throw new FileNotFoundException(string.Format("Path: {0} does not exist", configuration.ConfigfilePath));
		}

		var lines = File.ReadLines(configuration.ConfigfilePath).ToList();

		foreach (string line in lines)
		{
			var splits = line.Split(';');
			var linetopic = splits[0].ToLower();

			if (linetopic.Equals("datafilenames"))
			{
				configuration.Datafilenames = splits[1].Split(',').ToList();
			}
			else if (linetopic.Equals("datamapping"))
			{
				string property = splits[1];
				string column = splits[2];

				if (int.TryParse(column, out int columnIndex))
				{
					configuration.Datamappings.Add(property, new DataMapping(property, columnIndex));
				}
			}
			else if (linetopic.Equals("valuemapping"))
			{
				string category = splits[1];
				string keyword = splits[2];
				string operation = splits[3];

				configuration.ValueMappings.Add(new ValueMapping(category, keyword, operation));
			}
		};

		return configuration;
	}
}

