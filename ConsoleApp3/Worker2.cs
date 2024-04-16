namespace ConsoleApp3;

/*
 Реализуйте класс Worker, который будет иметь следующие свойства: name,
surname, rate (ставка за день работы), days (количество отработанных дней). Также класс
должен иметь метод GetSalary(), который будет выводить зарплату работника. Зарплата -
это произведение ставки rate на количество отработанных дней days
 */

public class Worker2
{
    private string Name { get; }
    private string Surname { get; }
    private int Rate { get; }
    private int Days { get; }

    public Worker2(string name, string surname, int rate, int days)
    {
        Name = name;
        Surname = surname;
        Rate = rate;
        Days = days;
    }

    public string GetName()
    {
        return Name;
    }
    
    public string GetSurname()
    {
        return Surname;
    }
    
    public int GetRate()
    {
        return Rate;
    }
    
    public int GetDays()
    {
        return Days;
    }
    
    public int GetSalary()
    {
        return Rate * Days;
    }
}