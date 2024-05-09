using System.Management;
using System.Runtime.InteropServices;
using System.Security;

[DllImport("Kernel32.dll"), SuppressUnmanagedCodeSecurity]
static extern int GetCurrentProcessorNumber();

foreach (var item in new ManagementObjectSearcher("Select * from Win32_Processor").Get())
{
    Console.WriteLine("Number Of Physical Core: {0}", item["NumberOfCores"]);
    Console.WriteLine("Number Of Logical Core: {0}", item["NumberOfLogicalProcessors"]);
}

List<Task> tasks = new List<Task>();

for(int i = 0; i < 14; i++)
{
    var taskI = i;
    tasks.Add(Task.Run(() => ThreadMethod(taskI)));
}

Task.WaitAll(tasks.ToArray());

void ThreadMethod(int threadId)
{ 
    for(int i = 0; i < 2; i++)
    {
        Console.WriteLine($"The Thread id:{threadId.ToString().PadLeft(3)} .... The processor id:{GetCurrentProcessorNumber().ToString().PadLeft(3)}");
        for(int x = 0; x < 100000; x++)
        {
            for (int y = 0; y < 10000; y++)
            {
            }
        }
    }
}



