// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
void start()
{
    Console.Clear();

    Console.WriteLine("Do you want to convert to or from Binary?");
    Console.WriteLine("dec for convert to binary and bin for from binary:");
    string inp = Console.ReadLine();
    if (inp == null)
    {
        start();
    }
    else if (inp == "dec")
    {
        dec();
    }
    else if (inp == "bin")
    {
        bin(); 
    }
    else
    {
        start();
    }
}
start();
void dec()
{
    Console.Clear();

    Console.WriteLine("Input a number:");
    string fin = "";
    double num = 0;
    double.TryParse(Console.ReadLine(), out num);
    int exp = Convert.ToInt32(Math.Floor(Math.Log2(num)));
    for (int i = exp; i >= 0; i--)
    {
        if (num >= Math.Pow(2, i) && num > 0)
        {
            num -= Math.Pow(2, i);
            fin += "1";
        }
        else
        {
            fin += "0";
        }
    }
    Console.WriteLine("");
    Console.WriteLine(fin);
    Console.WriteLine("do you want to go again? Y/N");
    string finInp = Console.ReadLine();
    if (finInp == "Y")
    {
        Console.Clear();
        start();
    }
    else
    {
        System.Environment.Exit(0);
    }
}
void bin()
{
    Console.Clear();

    Console.WriteLine("Input a number in binary:");
    double fin = 0;
    string inp = Console.ReadLine();
    if (IsDigitsOnly(inp))
    {
        char[] newNum = inp.ToCharArray();
        Array.Reverse(newNum);
        for (int i = 0; i< newNum.Length; i++)
        {
            if (newNum[i] == '1')
            {
                fin += Math.Pow(2, i);
            }
        }
        Console.WriteLine("");
        Console.WriteLine(fin);
        Console.WriteLine("do you want to go again? Y/N");
        string finInp=Console.ReadLine();
        if (finInp == "Y")
        {
            Console.Clear();
            start();
        }
        else
        {
            System.Environment.Exit(0);
        }
    }
    else
    {
        bin();
    }



}
bool IsDigitsOnly(string str)
{
    foreach (char c in str)
    {
        if (c >= '0' || c <= '1')
            return true;
    }

    return false;
}

