using System.Diagnostics;

namespace asynchron
{
    internal class Program
    {
        static string ProcessData(string dataName)
        {
            Console.WriteLine($"Синхронная обработка {dataName}");
            Thread.Sleep(3000);
            return $"Обработка '{dataName}' завершена за 3 секунды";
        }
        static async Task<string> ProcessDataAsync(string dataName)
        {
            Console.WriteLine($"Асинхронная обработка {dataName}");
            await Task.Delay(3000);
            return $"Обработка '{dataName}' завершена за 3 секунды";
        }

        static async Task Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(ProcessData("Файл 1"));
            Console.WriteLine(ProcessData("Файл 2"));
            Console.WriteLine(ProcessData("Файл 3"));
            stopwatch.Stop();
            Console.WriteLine($"Cинхронная обработка выполнена за: {stopwatch.Elapsed.TotalSeconds} секунд\n");

            stopwatch.Restart();
            var task1 = ProcessDataAsync("Файл 1");
            var task2 = ProcessDataAsync("Файл 2");
            var task3 = ProcessDataAsync("Файл 3");
                        
            var results = await Task.WhenAll(task1, task2, task3);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            stopwatch.Stop();
            Console.WriteLine($"Асинхронная обработка выполнена за: {stopwatch.Elapsed.TotalSeconds} секунд\n");

        }
    }
}

