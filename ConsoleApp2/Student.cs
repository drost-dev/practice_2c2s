namespace ConsoleApp2;

/*Задание 1. Создайте класс с именем Student, содержащий свойства: фамилия, дата
рождения, номер группы, успеваемость (массив из пяти элементов). Добавить возможность
изменения фамилии, даты рождения и номера группы. Добавить возможность вывода
информации о студенте, фамилия и дата рождения которого введены пользователем.
Написать программу, демонстрирующую все возможности класса;*/

public class Student
{
    public string Surname { get; set; }
    public string DateOfBirth { get; set; }
    public string GroupNumber { get; set; }
    public int[] Marks { get; }

    public Student(string surname, string dateOfBirth, string groupNumber, int[] marks)
    {
        Surname = surname;
        DateOfBirth = dateOfBirth;
        GroupNumber = groupNumber;
        Marks = marks;
    }

    public void Info()
    {
        Console.Write($"Фамилия: {Surname}\nДата рождения: {DateOfBirth}\nНомер группы: {GroupNumber}\nУспеваемость: ");
        
        foreach (var m in Marks)
        {
            Console.Write($"{m} ");
        }

        Console.WriteLine();
    }
}