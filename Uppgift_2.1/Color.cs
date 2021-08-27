using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2._1
{
    public class Color
    {

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Alpha { get; set; }

        public Color(int R, int G, int B, int A)
        {
            this.Red = R;
            this.Green = G;
            this.Blue = B;
            this.Alpha = A;
        }
        public Color(int R, int G, int B)
        {
            this.Red = R;
            this.Green = G;
            this.Blue = B;
            this.Alpha = 255;
        }
        public int GreyScale()
        {
            return (int)Math.Round((Red + Green + Blue) / 3.0, MidpointRounding.AwayFromZero);
        }
    }
}
