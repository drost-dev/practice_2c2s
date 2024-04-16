namespace ConsoleApp2;

/*
    Задание 5. Создать класс с двумя свойствами. Добавить конструктор с входными
    параметрами. Добавить конструктор, инициализирующий свойства по умолчанию.
    Добавить деструктор, выводящий на экран сообщение об удалении объекта. Написать
    программу, демонстрирующую все возможности класса;
 */

public class SomeClass
{
    public int Prop1 { get; set; }
    public string Prop2 { get; set; }

    public SomeClass(int prop1 = 0, string prop2 = "aaaaaaaaaa")
    {
        Prop1 = prop1;
        Prop2 = prop2;
    }

    ~SomeClass()
    {
        Console.WriteLine($"Instance of {this.GetType()} with Prop1 = {Prop1}, Prop2 = {Prop2} was deleted.");
    }
}