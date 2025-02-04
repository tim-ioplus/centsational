namespace CSDomain;

public class Transaction
{
	public DateTime Date;
	public string Receiver = "";
	public string Subject = "";
	public string Description = "";
	public decimal Value;

	public override string ToString()
	{
		return string.Format("Date: {0}, Value: {1}, Receiver: {2}, Subject: {3}, Description: {4}", Date, Value, Receiver, Subject, Description);
	}
}
