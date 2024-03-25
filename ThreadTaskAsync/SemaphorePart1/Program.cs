// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var resource = new Resource();
var p = Task.Run(() => Produce(resource));
var c = Task.Run(() => Consume(resource));
Task.WaitAll(p, c);


void Produce(Resource r)
{
    for (int i = 0; i < 100; i++)
    {
        r.Add(i);
    Console.WriteLine($">>>>> Produced {i}");
    }
}

void Consume(Resource r)
{
    for (int i = 0; i < 100; i++)
    {
        var x = r.Get();
        Console.WriteLine($"Consumed <<<<< {x}");
    }
}



public class Resource
{
    private SemaphoreSlim elementSemaphore = new SemaphoreSlim(0);

    private Queue<int> _queue = new Queue<int>();

    public void Add(int number)
    {
        _queue.Enqueue(number);
        elementSemaphore.Release();
    }

    public int Get()
    {
        elementSemaphore.Wait();
        var element = _queue.Dequeue();
        return element;
    }
}
