namespace asynchron
{
    internal class Program
    {
        static string ProcessData(string dataName)
        {
            Thread.Sleep(3000);
            return $"Обработка '{dataName}' завершена за 3 секунды";
        }

        static void Main(string[] args)
        {       
            Console.WriteLine(ProcessData("файл1"));
            Console.WriteLine(ProcessData("файл2"));
            Console.WriteLine(ProcessData("файл3"));
        }
    }
}

