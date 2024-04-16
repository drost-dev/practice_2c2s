namespace ConsoleApp3;

/*
 Реализуйте класс Worker, который будет иметь следующие свойства: name,
surname, rate (ставка за день работы), days (количество отработанных дней). Также класс
должен иметь метод GetSalary(), который будет выводить зарплату работника. Зарплата -
это произведение ставки rate на количество отработанных дней days
 */

public class Worker1
{
    public string Name { get; }
    public string Surname { get; }
    public int Rate { get; }
    public int Days { get; }

    public Worker1(string name, string surname, int rate, int days)
    {
        Name = name;
        Surname = surname;
        Rate = rate;
        Days = days;
    }
    
    public int GetSalary()
    {
        return Rate * Days;
    }
}