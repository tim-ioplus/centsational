namespace CSDomain;

public static class PathHelper
{
	public static string GetDirectoryPath(string filepath)
	{
		var filename = GetFileName(filepath);
		var dirpath = filepath.Replace("/" + filename, "");

		return dirpath;
	}

	public static string GetFileName(string filepath)
	{
		var splitted = filepath.Split("/");
		var filename = splitted[splitted.Length - 1];

		return filename;
	}
}
