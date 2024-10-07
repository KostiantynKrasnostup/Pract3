using System;

internal class Arrays
{
    private int[] a;
    private int length;

    // Конструктор, який ініціалізує масив заданого розміру
    public Arrays(int size)
    {
        a = new int[size];
        length = size;
    }

    // Властивість, яка повертає довжину масиву
    public int Length => length;

    // Статичний метод, який генерує випадковий масив
    public static Arrays GenerateRandomArray(Arrays array)
    {
        // Створіть об'єкт класу Random для генерування випадкових чисел
        Random rand = new Random();
        // Генеруємо випадкові значення для кожного елемента масиву
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(0, 100);
        }
        return array;
    }

    // Статичний оператор, який множить масив на задане число
    public static Arrays operator *(Arrays arrays, int mul)
    {
        // Створіть новий масив того ж розміру, що і вхідний
        Arrays resArray = new Arrays(arrays.Length);
        // Множимо кожен елемент масиву на задане число
        for (int i = 0; i < arrays.Length; i++)
        {
            resArray[i] = arrays[i] * mul;
        }
        return resArray;
    }

    // Індексатор, який дозволяє доступ до елементів масиву
    public int this[int i]
    {
        get => (i >= 0 && i < length) ? a[i] : throw new IndexOutOfRangeException("Індекс виходить за межі");
        set
        {
            if (i >= 0 && i < length && value >= -100 && value <= 10000)
                a[i] = value;
            else
                throw new ArgumentOutOfRangeException("Індекс або значення виходять за межі");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Введіть розмір масиву
            Console.Write("Введіть розмір масиву: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Введіть множник
            Console.Write("Введіть множник: ");
            int mul = Convert.ToInt32(Console.ReadLine());

            // Створіть масив заданого розміру
            Arrays a = new Arrays(n);
            // Генеруємо випадковий масив
            a = Arrays.GenerateRandomArray(a);

            // Виводимо початковий масив
            Console.WriteLine("Початковий масив:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();

            // Множимо масив на задане число
            Arrays resArray = a * mul;

            Console.WriteLine($"Масив після множення на {mul}:");
            for (int i = 0; i < resArray.Length; i++)
            {
                Console.Write(resArray[i] + " ");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Некоректний ввід. Будь ласка, введіть числові значення.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}