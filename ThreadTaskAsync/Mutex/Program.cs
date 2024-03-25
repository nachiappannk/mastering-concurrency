//Locks for shared resources
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Object obj  = new Object();

var t1 = Task.Run(() =>
    { 
        for(int i = 0; i < 100; i++)
        {
            lock (obj)
            { 
                PrintLabel1();
            }
        }
    });

var t2 = Task.Run(() =>
{
    for (int i = 0; i < 100; i++)
    {
        lock (obj)
        {
            PrintLabel2();
        }
    }
});

Task.WaitAll(t1, t2);



void PrintLabel1()
{
    var color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("****************************************************");
    Console.WriteLine("****************************************************");
    Console.WriteLine("*                  LABEL 1                         *");
    Console.WriteLine("****************************************************");
    Console.WriteLine("****************************************************");
    Console.WriteLine();
    Console.ForegroundColor = color;
}


void PrintLabel2()
{
    var color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("-                  LABEL 2                         -");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine();
    Console.ForegroundColor = color;
}