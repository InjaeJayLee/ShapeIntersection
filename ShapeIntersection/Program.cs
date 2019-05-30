using System;
using System.Collections.Generic;

namespace ShapeIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>();

            // example
            Circle c1 = new Circle(1, 3.0f, new Vector2(-3.0f, -1.0f));
            Circle c2 = new Circle(2, 2.3f, new Vector2(1.0f, 3.0f));
            Rectangle r1 = new Rectangle(3, new Vector2(-1.85f, 3.99f), 1.42f, 2.08f);
            Rectangle r2 = new Rectangle(4, new Vector2(-3.0f, 2.0f), 2.0f, 4.0f);
            Circle c3 = new Circle(5, 5.0f, new Vector2(1.64f, -1.43f));

            shapes.Add(c1);
            shapes.Add(c2);
            shapes.Add(r1);
            shapes.Add(r2);
            shapes.Add(c3);

            var resultDic = Util.FindIntersections(shapes);

            // output the result
            foreach (var list in resultDic)
            {
                Console.Write("\nID {0}: ", list.Key);
                foreach (var item in list.Value)
                {
                    Console.Write("{0} ", item);
                }
            }
        }
    }
}
