namespace HalloDelegates
{
    internal delegate string MyDelegate(int i, double d);

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = new MyDelegate(MeineWichtigeMethode);

            var result = del.Invoke(6, 8.0);

            System.Console.WriteLine(result);
        }

        private static string MeineWichtigeMethode(int zahl, double wert) => (zahl + wert).ToString();
    }
}
