using DAL;
using PL;
int check = 0;
GpaPL pl = new GpaPL();
GpaDAL dal = new GpaDAL();
while (check != 2)
{
    int sel = pl.MainMenu();
    if (sel == 1)
    {
        pl.EnterStudent();
        
    }
    else if (sel == 2)
    {
        pl.DisplayStudent();
    }
    else if (sel == 3)
    {
        break;
    }
    Console.WriteLine("\nDo You Want To Perform Another Operation?: \n");
    Console.WriteLine("1. Yes");
    Console.WriteLine("2. No\n");
    Console.Write("Your Choice: ");
    Console.ForegroundColor = ConsoleColor.Green;
    check = int.Parse(Console.ReadLine());
    while (check <= 0 || check > 2)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("***Wrong Input***\n");
        Console.WriteLine("***Enter Again***\n");
        Console.ForegroundColor = ConsoleColor.Green;
        check = int.Parse(Console.ReadLine());
    }
    Console.ResetColor();
}
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("\n***Program Exits***\n");
Console.ResetColor();
