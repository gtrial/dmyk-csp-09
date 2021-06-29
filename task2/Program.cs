using System;

namespace task2
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(GC.GetTotalMemory(true));
            MyClass.MakeSomeGarbage();
            Console.WriteLine(GC.GetTotalMemory(true));
            Console.WriteLine("Insert memory limit:");

            if (int.TryParse(Console.ReadLine(), out var memoryLimit))
            {
                MyClass.CheckLimits(memoryLimit);
            }
            else
            {
                Console.WriteLine("Invalid limit value");
            }
        }
    }

    internal class MyClass
    {
        private const long MaxGarbage = 1000;

        public static void MakeSomeGarbage()
        {
            Version vt = null;

            for (var i = 0; i < MaxGarbage; i++)
            {
                vt = new Version();
            }

            if (vt is not null) Console.WriteLine(vt.ToString());
        }

        public static void CheckLimits(int memoryLimit)
        {
            var totalMemory = GC.GetTotalMemory(true);
            if (totalMemory > memoryLimit)
            {
                Console.WriteLine($"Memory allocated {totalMemory} is over the limit of {memoryLimit}");
            }
        }
    }
}