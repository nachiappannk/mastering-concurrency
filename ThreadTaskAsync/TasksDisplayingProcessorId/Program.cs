// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using System.Security;

Console.WriteLine("Hello, World!");


[DllImport("Kernel32.dll"), SuppressUnmanagedCodeSecurity]
static extern int GetCurrentProcessorNumber();

List<Task> tasks = new List<Task>();

tasks.Add(Task.Run(() => RunTask(1)));
tasks.Add(Task.Run(() => RunTask(2)));
tasks.Add(Task.Run(() => RunTask(3)));
tasks.Add(Task.Run(() => RunTask(4)));
tasks.Add(Task.Run(() => RunTask(5)));

Task.WaitAll(tasks.ToArray());

void RunTask(int taskId)
{
    for (int i = 0; i < 10; i++)
    { 
        Console.WriteLine($"Task {taskId} - {GetCurrentProcessorNumber()}");
        Thread.Sleep(100);
    }

}