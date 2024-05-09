

Object obj  = new Object();

var t1 = Task.Run(() =>
    { 
        for(int i = 0; i < 3; i++)
        {
            lock (obj)
            { 
                PrintLabel1();
            }
        }
    });

var t2 = Task.Run(() =>
{
    for (int i = 0; i < 3; i++)
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
    for (int i = 0; i < 5; i++)
    {
        for (int j = i; j < 5; j++)
        {
            Console.Write("*");
            Thread.Sleep(100);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}


void PrintLabel2()
{
    for (int i = 0; i < 5; i++)
    {
        for (int j = i; j < 5; j++)
        {
            Console.Write("#");
            Thread.Sleep(100);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}