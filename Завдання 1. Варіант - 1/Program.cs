using System;

public class TLine2D
{
    // Поля для зберігання коефіцієнтів канонічного рівняння прямої
    private double k; // Коефіцієнт k
    private double b; // Вільний член b

    // Конструктор без параметрів
    public TLine2D()
    {
        k = 0;
        b = 0;
    }

    // Конструктор з параметрами
    public TLine2D(double k, double b)
    {
        this.k = k;
        this.b = b;
    }

    // Метод для введення даних
    public void Input()
    {
        Console.Write("Введіть коефіцієнт k: ");
        k = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть вільний член b: ");
        b = Convert.ToDouble(Console.ReadLine());
    }

    // Метод для виведення даних
    public void Output()
    {
        Console.WriteLine($"Пряма: y = {k}x + {b}");
    }

    // Метод для знаходження точки перетину з іншою прямою
    public (double x, double y)? Intersect(TLine2D other)
    {
        if (this.k == other.k)
        {
            return null; // Прямі паралельні
        }

        double x = (other.b - this.b) / (this.k - other.k);
        double y = this.k * x + this.b;
        return (x, y);
    }

    // Метод для перевірки належності точки прямій
    public bool BelongsToLine(double x, double y)
    {
        return Math.Abs(y - (k * x + b)) < 1e-10; // Точність перевірки
    }

    // Перевантаження оператора +
    public static TLine2D operator +(TLine2D line1, TLine2D line2)
    {
        return new TLine2D(line1.k + line2.k, line1.b + line2.b);
    }

    // Перевантаження оператора -
    public static TLine2D operator -(TLine2D line1, TLine2D line2)
    {
        return new TLine2D(line1.k - line2.k, line1.b - line2.b);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TLine2D line1 = new TLine2D();
        TLine2D line2 = new TLine2D();

        Console.WriteLine("Введіть першу пряму");
        line1.Input();

        Console.WriteLine("Введіть другу пряму");
        line2.Input();

        Console.WriteLine("\nПерша пряма:");
        line1.Output();

        Console.WriteLine("Друга пряма:");
        line2.Output();

        // Знаходження точки перетину
        var intersection = line1.Intersect(line2);
        if (intersection.HasValue)
        {
            Console.WriteLine($"Точка перетину: x = {intersection.Value.x}, y = {intersection.Value.y}");
        }
        else
        {
            Console.WriteLine("Прямі паралельні, немає точки перетину.");
        }

        // Перевірка належності точки
        Console.Write("Введіть координати точки для перевірки (x, y): ");
        double x = Convert.ToDouble(Console.ReadLine());
        double y = Convert.ToDouble(Console.ReadLine());
        if (line1.BelongsToLine(x, y))
        {
            Console.WriteLine("Точка належить першій прямій.");
        }
        else
        {
            Console.WriteLine("Точка не належить першій прямій.");
        }

        // Перевірка операцій +
        TLine2D lineSum = line1 + line2;
        Console.WriteLine("Сума прямих:");
        lineSum.Output();

        // Перевірка операцій -
        TLine2D lineDiff = line1 - line2;
        Console.WriteLine("Різниця прямих:");
        lineDiff.Output();
    }
}
