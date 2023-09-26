public class Ar
{
    private int n;   // Кількість елементів в масиві
    private int[] a; // Одновимірний цілочисельний масив
    private int s;   // Сума елементів масиву, які менше 50

    // Конструктор 1, з двома натуральними параметрами(a і b), 
    // використовується для заповнення масиву кубами чисел в діапазоні [a; b]
    public Ar(int a, int b)
    {
        n = (b - a + 1);
        this.a = new int[n];
        for (int i = 0; i < n; i++)
        {
            this.a[i] = (a + i) * (a + i) * (a + i);
        }
    }

    // Конструктор 2, з одним параметром строкового типу, який приймає ім'я текстового файлу,
    // з якого потім зчитує числа і заповнює масив
    public Ar(string fileName)
    {
        string[] numbers = File.ReadAllText(fileName).Split(':');
        n = numbers.Length;
        a = new int[n];
        // Заповнення масиву числами з файлу
        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(numbers[i]);
        }
    }

    // Властивість для читання поля n
    public int N
    {
        get { return n; }
    }

    // Властивість для читання суми елементів масиву, які менше 50
    public int S
    {
        get
        {
            s = 0;
            foreach (int element in a)
            {
                if (element < 50)
                {
                    s += element;
                }
            }
            return s;
        }
    }

    // Метод для виведення масиву на екран
    public void Print()
    {
        Console.Write("Масив:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(" {0} ", a[i]);
        }
        Console.WriteLine();
    }

    // Метод для знаходження індексу останнього непарного елемента
    public int P()
    {
        for (int i = n - 1; i >= 0; i--)
        {
            if (a[i] % 2 != 0)
            {
                return i;
            }
        }
        return -1; // Якщо немає непарних елементів
    }

    // Метод для обчислення суми елементів масиву з індексами від i1 до i2 включно
    public int Sum(int i1, int i2)
    {
        int sum = 0;
        for (int i = i1; i <= i2; i++)
        {
            sum += a[i];
        }
        return sum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Ar mas;
        Console.Write("Конструктор 1/2 --> ");
        int r = Convert.ToInt32(Console.ReadLine());
        if (r == 1)
        {
            Console.Write("Введіть a --> ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть b --> ");
            int b = Convert.ToInt32(Console.ReadLine());
            mas = new Ar(a, b);
        }
        else if (r == 2)
        {
            mas = new Ar("1.txt");
        }
        else
        {
            Console.WriteLine("Такого конструктора немає");
            return;
        }

        mas.Print();

        int sum = mas.S;
        Console.WriteLine("Сума елементів < 50 = {0}", sum);

        int index = mas.P();
        if (index != -1)
        {
            Console.WriteLine("Індекс останнього непарного елемента = {0}", index);
            int s = mas.Sum(0, index);
            Console.WriteLine("Сума елементів ліворуч від останнього непарного = {0}", s);
        }
        else
        {
            Console.WriteLine("Немає непарних елементів в масиві");
        }
        Console.ReadKey();
    }
}
