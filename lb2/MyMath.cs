using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2
{
    class MyMath
    {
        public static double Cos(double x)
        {
            double t = 1;
            double sum = 1;
            int p = 0;
            while (Math.Abs(t / sum) > 0)
            {
                p++;
                t = (-t * x * x) / ((2 * p - 1) * (2 * p));
                sum += t;
            }
            return sum;
        }

        public static double Sin(double x)
        {
            const double eps = 1e-15;
            double sum = 0;
            double r = x;
            int n = 1;
            while (Math.Abs(r) > eps)
            {
                sum = sum + r;
                n = n + 2;
                r = -r * x * x / (n * (n - 1));
            }
            return sum;
        }
        public static double Cot(double x) //котангенс
        {
            return Cos(x) / Sin(x);
        }

        public static double Csc(double x) //косеканс
        {
            return 1 / Math.Sqrt(1 - Math.Pow(Cos(x), 2));
        }
        public static double Sec(double x)  //секанс
        {
            return 1 / Cos(x);
        }

        public static double Arctn(double x)
        {
            const double e = 0.000000000000001;
            double summ = x;
            double sum = x;
            for (int n = 0; Math.Abs(summ) > e; n++)
            {
                summ *= -1 * x * x;
                sum += summ / (2 * n + 3);
            }
            return sum;
        }

        public static double Ln(double x) //натуральный логарифм
        {
            if (x == 0)
            {
                return double.NegativeInfinity;
            }
            if (x < 0)
            {
                return double.NaN;
            }
            double count = 1;
            double totalValue = 0;
            double Iterations = 1000;
            double z = 1;
            double powe = 1;
            double y;

            while (count <= Iterations)
            {
                for (int i = 0; i < powe; i++)
                {
                    z *= (x - 1) / (x + 1);
                }
                y = (1 / powe) * z;

                totalValue = totalValue + y;
                powe = powe + 2;
                count++;
                z = 1;
            }
            return 2 * totalValue;
        }
        public static double Log(double x, double y) //логарифм
        {
            if ((y > 0) && (y != 1) && (x > 0))
            {
                return Ln(x) / Ln(y);
            }
            if ((y < 0) && (x == 1))
            {
                return double.NaN;
            }
            if ((y == 0) && (x == 1))
            {
                return 0;
            }
            if ((y != 1) && (x == 1))
            {
                return 0;
            }
            if ((x == 0) && (y != 1) && (y > 0))
            {
                return Double.NegativeInfinity;
            }
            return double.NaN;
        }



        public double CalculateResult(Func<double, double> CountSin, Func<double, double> CountCos, Func<double, double> LnCount, Func<double, double, double> LogCount, double x)
        {
            if (x <= 0)
            {
                return Math.Pow((((1/CountSin(x)) / CountSin(x)) - CountSin(x)) * CountSin(x),3) - (CountSin(x) * Math.Pow(CountCos(x)/CountSin(x) - 1/CountCos(x),3));
            }
            if (x > 0)
            {
                return (Math.Pow(LnCount(x) * LogCount(x, 3), 3) + LogCount(x, 10)) / Math.Pow(LogCount(x, 3), 2);
            }
            return 0;
        }
    }
}