namespace ConsoleApp2;

/*Задание 4. Описать класс, реализующий счетчик, который может увеличивать или
    уменьшать свое значение на единицу. Предусмотреть инициализацию счетчика со
    значением по умолчанию и произвольным значением. Счетчик имеет два метода:
    увеличения и уменьшения, — и свойство, позволяющее получить его текущее состояние.
    Написать программу, демонстрирующую все возможности класса;*/

public class Counter
{
    public int Value { get; private set; }

    public Counter(int initialValue = 0)
    {
        Value = initialValue;
    }

    public void Increase()
    {
        Value++;
    }
    
    public void Decrease()
    {
        Value--;
    }
}