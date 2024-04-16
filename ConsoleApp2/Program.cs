namespace ConsoleApp2;

public class Program
{
    /*
    Задание 1. Создайте класс с именем Student, содержащий свойства: фамилия, дата
    рождения, номер группы, успеваемость (массив из пяти элементов). Добавить возможность
    изменения фамилии, даты рождения и номера группы. Добавить возможность вывода
    информации о студенте, фамилия и дата рождения которого введены пользователем.
    Написать программу, демонстрирующую все возможности класса;
    
        Student[] students = new Student[]
        {
            new Student("Петров", "12.07.2000", "316Б", new int[]{5, 3, 4, 5, 4}),
            new Student("Сорокин", "03.01.2001", "326Б", new int[]{5, 4, 4, 5, 5}),
            new Student("Мельников", "24.09.2000", "314", new int[]{4, 3, 3, 5, 4}),
            new Student("Макарова", "17.11.2000", "314", new int[]{3, 3, 5, 4, 5}),
        };

        string inputSurname = "Сорокин";
        string inputDate = "03.01.2001";
        bool foundStudent = false;
        
        foreach (var student in students)
        {
            if (student.Surname == inputSurname && student.DateOfBirth == inputDate)
            {
                student.Info();
                foundStudent = true;
            }
        }
        
        if (!foundStudent) Console.WriteLine("Такого студента нет!");
    
    Задание 2. Создайте класс с именем Train, содержащий свойства: название пункта
    назначения, номер поезда, время отправления. Добавить возможность вывода
    информации о поезде, номер которого введен пользователем. Написать программу,
    демонстрирующую все возможности класса;
    
        Train[] trains = new Train[]
        {
            new Train("Томск", "2132", "16:30"),
            new Train("Омск", "542", "8:20"),
            new Train("Москва", "2451", "10:15")
        };

        string inputNumber = "2132";
        bool foundTrain = false;
        
        foreach (var train in trains)
        {
            if (train.Number == inputNumber)
            {
                train.Info();
                foundTrain = true;
            }
        }
        
        if (!foundTrain) Console.WriteLine("Такого поезда нет!");
    
    Задание 3. Создайте класс с двумя свойствами для хранения целых чисел. Добавить
    метод для вывода на экран и метод для изменения этих чисел. Добавить метод, который
    находит сумму значений этих чисел, и метод который находит наибольшее значение из
    этих чисел. Написать программу, демонстрирующую все возможности класса;
    
        Nums n = new Nums(7, 15);
        
        n.Display();
        Console.WriteLine($"Сумма чисел: {n.Sum()}");
        Console.WriteLine($"Наибольшее: {n.Greatest()}");
        
        n.Update(12, 1);
        
        n.Display();
        Console.WriteLine($"Сумма чисел: {n.Sum()}");
        Console.WriteLine($"Наибольшее: {n.Greatest()}");
    
    Задание 4. Описать класс, реализующий счетчик, который может увеличивать или
    уменьшать свое значение на единицу. Предусмотреть инициализацию счетчика со
    значением по умолчанию и произвольным значением. Счетчик имеет два метода:
    увеличения и уменьшения, — и свойство, позволяющее получить его текущее состояние.
    Написать программу, демонстрирующую все возможности класса;
    
        Counter c = new Counter(89);
        Console.WriteLine($"counter is {c.Value}");
        c.Increase();
        Console.WriteLine($"counter is {c.Value}");
        c.Increase();
        Console.WriteLine($"counter is {c.Value}");
        c.Decrease();
        Console.WriteLine($"counter is {c.Value}");
    
    Задание 5. Создать класс с двумя свойствами. Добавить конструктор с входными
    параметрами. Добавить конструктор, инициализирующий свойства по умолчанию.
    Добавить деструктор, выводящий на экран сообщение об удалении объекта. Написать
    программу, демонстрирующую все возможности класса;
    
    static void Main()
    {
        Test();
        GC.Collect();
    }

    static void Test()
    {
        SomeClass sc = new SomeClass(prop1: 4564);
        Console.WriteLine($"sc.Prop1 = {sc.Prop1}, sc.Prop2 = {sc.Prop2}");
    }
     */
    
    
    
    static void Main()
    {
        
    }
}