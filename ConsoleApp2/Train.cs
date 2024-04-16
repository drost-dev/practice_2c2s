namespace ConsoleApp2;

/*Задание 2. Создайте класс с именем Train, содержащий свойства: название пункта
    назначения, номер поезда, время отправления. Добавить возможность вывода
    информации о поезде, номер которого введен пользователем. Написать программу,
    демонстрирующую все возможности класса;*/

public class Train
{
    public string Destination { get; }
    public string Number { get; }
    public string DepartTime { get; }

    public Train(string destination, string number, string departTime)
    {
        Destination = destination;
        Number = number;
        DepartTime = departTime;
    }

    public void Info()
    {
        Console.WriteLine($"Пункт назначения: {Destination}\nНомер поезда: {Number}\nВремя отправления: {DepartTime}");
    }
}