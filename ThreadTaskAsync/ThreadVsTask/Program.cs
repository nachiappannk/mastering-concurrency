//Task are better than Threads
// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");


int[] numbers = new int[] { 
    104179, 102342, 104183, 104207, 
    104233, 104239, 104243, 104281,
    104287, 104297, 104309, 104311,
    104323, 104327, 104347, 104369,
    104381, 104383, 104393, 104399,
    104417, 104231 };

List<int> inputNumbers = new List<int>(numbers);
for (int i = 0; i < 30; i++)
{
    inputNumbers.AddRange(numbers);
}

MeasureTime("Tasks", () => { CheckViaTasks(inputNumbers); });
Task.Delay(1000).Wait();
MeasureTime("Thread", () => { CheckViaThread(inputNumbers); });


static void MeasureTime(string name, Action action)
{
    Stopwatch sw = new Stopwatch();
    sw.Start();
    action();
    sw.Stop();
    Console.WriteLine("Elapsed for {0}={1}", name, sw.ElapsedMilliseconds);
}


static bool IsPrime(int number)
{
    for (int i = 2; i < number - 1; i++)
    {
        var reminder = number % i;
        if (reminder == 0)
        {
            return false;
        }
    }
    return true;
}

static void CheckViaThread(List<int> inputNumbers)
{
    var threads = inputNumbers.Select(x =>
    {
        var thread = new Thread(() =>
        {
            var isPrime = IsPrime(x);
            //Console.WriteLine($"{x} is prime: {isPrime}");
        });
        thread.Start();
        return thread;
    }).ToList();

    foreach (var thread in threads)
    {
        thread.Join();
    }
}

static void CheckViaTasks(List<int> inputNumbers)
{
    Task.Run(() =>
    {
        var tasks = inputNumbers.Select(x =>
        {
            return Task.Run(() =>
            {
                var isPrime = IsPrime(x);
                //Console.WriteLine($"{x} is prime: {isPrime}");
            });
        }).ToList();

        Task.WaitAll(tasks.ToArray());

    }).Wait();
}