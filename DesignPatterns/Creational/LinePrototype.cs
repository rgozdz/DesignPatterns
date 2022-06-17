namespace DesignPatterns.Creational
{
    public class LinePrototype
    {
        public class Point
        {
            public int X, Y;
        }

        public class Line
        {
            public Point Start, End;

            public Line DeepCopy()
            {
                return new Line()
                {
                    Start = new Point {X = this.Start.X, Y = this.Start.Y},
                    End = new Point {X = this.End.X, Y = this.End.Y},
                };
            }
        }
    }
}
