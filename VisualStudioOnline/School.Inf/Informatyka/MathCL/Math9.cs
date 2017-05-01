using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math9
{
    public class Vector
    {
        double Heading;
        double Length;
        double DirX;
        double DirY;
        
        public void Vector(double path, bool direction, double value)
        {
            Heading = path;
            if (!direction) Heading += 180;
            Length = value;

            while (Heading >= 360) Heading -= 360;

            DirX = value * Math.Cos(Heading);
            DirY = value * Math.Sin(Heading) * (-1);
        }

        public void Vector(double x, double y)
        {
            DirX = x;
            DirY = y;

            Heading = Math.Atan2(-y, x);
            Length = Math.Sqrt(x * x + y * y);
        }
    }

    public class Func
    {
        
        public static int Power(int x, int y)
        {
            if (y == 0) return 1;
            int result = x;
            for (int i = 1; i < y; i++)
            {
                result *= x;
            }
            return result;
        }
    }

    
}
