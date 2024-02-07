// See https://aka.ms/new-console-template for more information
using Account.Service;

Console.WriteLine("Hello, World!");
var serv = new AccountService();
for (int i = 0; i <= 5; i++)
{
    bool result = serv.IsEven(i);
    string text = result ? "{0} is even" : "{0} is uneven";
    Console.WriteLine(string.Format(text, i));
}

Console.WriteLine("Finished");