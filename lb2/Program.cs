using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lb2
{
    class Program
    {
        static string path = @"E:\Inctitute\4 курс 1 семестр\ТПО\лб2\результаты\";
        static MyMath result = new MyMath();

        static void Main(string[] args)
        {
            double e_left = Math.Round(-(Math.PI / (double)2), 2, MidpointRounding.AwayFromZero) ;
            double e_right = Math.Round((Math.PI / (double)2), 2, MidpointRounding.AwayFromZero);
            int c = 0;
            int cc = 0;
            for (double x = e_left; x <= e_right; x += 0.01)
            {
                if (x != 0)
                {
                    double x1 = Math.Round(result.CalculateResult(MyMath.Sin, MyMath.Cos, MyMath.Ln, MyMath.Log, x), 3, MidpointRounding.AwayFromZero);
                    double x2 = Math.Round(result.CalculateResult(Math.Sin, Math.Cos, Math.Log, Math.Log, x),  3, MidpointRounding.AwayFromZero);
                    if (x1.Equals(x2))
                    {
                        c++;
                    }
                    else
                    {
                        double xxx1 = MyMath.Sin(x);
                        double xxx2 = MyMath.Cos(x);
                        double xxx3 = Math.Sin(x);
                        double xxx4 = Math.Cos(x);

                        double erewr2 = MyMath.Sin(x) / MyMath.Cos(x);
                        double erewr = Math.Tan(x);
                    }

                    cc++;
                }
            }



            int value_left = -10;
            int value_right = 10;
            double step = 0.01;

            CountCos(path + "CosReport", value_left, value_right, step);
            CountSin(path + "SinReport", value_left, value_right, step);
            CountLog(path + "LogReport", value_left, value_right, step*100);
            CountResult(path + "CommonExpReport", value_left, value_right, step*10);
        }
        private static void CountCos(string name, int left, int right, double step)
        {
            string path = $"{name}.csv";
            using (FileStream fs = File.Create(path))  { fs.Close(); }
            StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);
            for (double x = left; x < right; x += step)
            {
                sw.WriteLine($"{Math.Round(x, 4)};  {Math.Round(MyMath.Cos(x), 12)};  {Math.Round(Math.Cos(x), 12)}");
            }
        }
        private static void CountSin(string name, int left, int right, double step)
        {
            string path = $"{name}.csv";
            using (FileStream fs = File.Create(path)) { fs.Close(); }
            StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);
            for (double x = left; x < right; x += step)
            {
                sw.WriteLine($"{Math.Round(x, 4)};   {Math.Round(MyMath.Sin(x), 12)};   {Math.Round(Math.Sin(x), 12)}");
            }
        }

        private static void CountLog(string name, int left, int right, double step)
        {
            string path = $"{name}.csv";
            using (FileStream fs = File.Create(path)) { fs.Close(); }
            StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);
            for (double x = left; x < right; x += step)
            {
                for (double y = left; y < right; y += step)
                {
                    sw.WriteLine($"{Math.Round(x, 4)};   {Math.Round(y, 4)}:{Math.Round(MyMath.Log(x, y), 12)};   {Math.Round(Math.Log(x, y), 12)}");
                }
            }
        }
        private static void CountResult(string name, int left, int right, double step)
        {
            string path = $"{name}.csv";
            using (FileStream fs = File.Create(path)) { fs.Close(); }
            int round_degreee = 12;
            StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);
            for (double x = left; x < right; x += step)
            {
                sw.WriteLine($"{Math.Round(x, round_degreee/3)}: " +
                    $"{Math.Round(result.CalculateResult(MyMath.Sin, MyMath.Cos, MyMath.Ln, MyMath.Log, x), round_degreee)};" +
                    $"    {Math.Round(result.CalculateResult(Math.Sin, Math.Cos, Math.Log, Math.Log, x), round_degreee)}");
            }
        }

    }
}
