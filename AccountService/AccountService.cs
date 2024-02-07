using System;
namespace Account.Service;

public class AccountService
{
    public bool IsEven(int candidate)
    {
        return candidate % 2 == 0;
    }

    
}