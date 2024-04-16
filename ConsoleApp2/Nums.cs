namespace ConsoleApp2;

/*Задание 3. Создайте класс с двумя свойствами для хранения целых чисел. Добавить
    метод для вывода на экран и метод для изменения этих чисел. Добавить метод, который
    находит сумму значений этих чисел, и метод который находит наибольшее значение из
    этих чисел. Написать программу, демонстрирующую все возможности класса;*/

public class Nums
{
    public int Num1 { get; private set; }
    public int Num2 { get; private set; }

    public Nums(int num1, int num2)
    {
        Num1 = num1;
        Num2 = num2;
    }

    public void Display()
    {
        Console.WriteLine($"Число 1: {Num1}\nЧисло 2: {Num2}");
    }
    
    public void Update(int num1, int num2)
    {
        Num1 = num1;
        Num2 = num2;
    }
    
    public int Sum()
    {
        return Num1 + Num2;
    }
    
    public int Greatest()
    {
        return Num1 > Num2 ? Num1 : Num2;
    }
}