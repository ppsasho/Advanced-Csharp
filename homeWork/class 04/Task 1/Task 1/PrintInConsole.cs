namespace Task_1
{
    public static class PrintInConsole
    {
        public static void Print<T>(this T item)
        {
            Console.WriteLine("Printing item...");
            Console.WriteLine(item);
        }
        public static void PrintCollection<T>(this List<T> items)
        {
            Console.WriteLine("Printing item collection...");
            foreach (T item in items) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
