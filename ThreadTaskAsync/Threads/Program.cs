
var thread1 = new Thread(() => WriteHash());
thread1.IsBackground = true;
thread1.Start();
WriteStar();


static void WriteHash()
{
    int i = 0;
    while (true)
    {
        i++;
        Console.WriteLine($"#### {i}");
        Thread.Sleep(200);
    }
}

static void WriteStar()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"* {i}");
        Thread.Sleep(250);
    }
}

