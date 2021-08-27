using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2._1
{
    class Ball
    {
        public float radius { get; set; }
        int thrown;
        public Color color { get; private set; }

        public Ball(float r, Color c)
        {
            this.radius = r;
            this.color = c;
            this.thrown = 0;
        }

        public void Shrink()
        {
            radius = 0;
            Console.WriteLine("\nBall shrunk into the void");
        }

        public void Throw()
        {
            if (radius > 0)
            {
                thrown++;
            }
        }

        public int ThrowAmount()
        {
            return thrown;
        }
    }
}
