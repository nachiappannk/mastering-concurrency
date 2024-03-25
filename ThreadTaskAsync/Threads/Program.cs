//Exploring Threads

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var thread1 = new Thread(() => MonitorSystem1());
var thread2 = new Thread(() => MonitorSystem2());
thread1.IsBackground = true;
thread2.IsBackground = true;
thread1.Start();
thread2.Start();
Thread.Sleep(30 * 1000);


static void MonitorSystem1()
{
    while (true)
    {
        var value = SimulateReadingSystem1();
        Console.WriteLine($"System1 value: {value}");
        Thread.Sleep(1000);
    }
}

static void MonitorSystem2()
{
    while (true)
    {
        var value = SimulateReadingSystem2();
        Console.WriteLine($"System2 value: {value}");
        Thread.Sleep(500);
    }
}


static int SimulateReadingSystem1()
{
    Thread.Sleep(100);
    return new Random().Next(1000);
}

static int SimulateReadingSystem2()
{
    Thread.Sleep(130);
    return new Random().Next(1000);
}