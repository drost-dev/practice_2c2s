namespace ConsoleApp3;

/*
Создайте класс Calculation , в котором будет одно свойство calculationLine.
методы: SetCalculationLine который будет который будет изменять значение свойства,
SetLastSymbolCalculationLine который будет в конец строки прибавлять символ,
GetCalculationLine который будет выводить значение свойства, GetLastSymbol получение
последнего символа, DeleteLastSymbol удаление последнего символа из строки;
 */

public class Calculation
{
    private string CalculationLine { get; set; }

    public Calculation(string calculationLine)
    {
        CalculationLine = calculationLine;
    }

    public void SetCalculationLine(string newLine)
    {
        CalculationLine = newLine;
    }
    
    public void SetLastSymbolCalculationLine(char c)
    {
        CalculationLine += c;
    }
    
    public string GetCalculationLine()
    {
        return CalculationLine;
    }
    
    public char GetLastSymbol()
    {
        return CalculationLine.Last();
    }

    public void DeleteLastSymbol()
    {
        CalculationLine = CalculationLine.Remove(CalculationLine.Length - 1, 1);
    }

}