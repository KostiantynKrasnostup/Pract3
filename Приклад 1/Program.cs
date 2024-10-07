namespace Sample01
{
    class Point
    {
        int x, y;
        Point()
        {
            x = 0;
            y = 0;
        }
        Point(Point key)
        {
            x = key.x;
            y = key.y;
        }
        public static Point operator ++(Point par)
        {
            par.x++;
            par.y++;
            return par;
        }
        public static Point operator --(Point par)
        {
            par.x--;
            par.y--;
            return par;
        }

        class Program
        {
            static void Main(string[] args)
            {
                Point p = new Point();
                p++;
                Console.WriteLine("x={0} y={1}", p.x, p.y);
                ++p;
                Console.WriteLine("x={0} y={1}", p.x, p.y);
                p--;
                Console.WriteLine("x={0} y={1}", p.x, p.y);
                --p;
                Console.WriteLine("x={0} y={1}", p.x, p.y);
            }
        }
    }
}