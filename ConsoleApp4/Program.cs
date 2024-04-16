namespace ConsoleApp4;

public class Program
{
    static void Main()
    {
        var symbs = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        char prevChar = ' ';
        Console.Write("Римское число: ");
        string romanNum = Console.ReadLine();
        int sum = 0;
        
        foreach (var c in romanNum)
        {
            switch (prevChar)
            {
                case 'I':
                    if (c == 'V' || c == 'X')
                    {
                        sum += (symbs[c] - 2 * symbs[prevChar]);
                    }
                    else
                    {
                        sum += symbs[c];
                    }
                    break;
                case 'X':
                    if (c == 'L' || c == 'C')
                    {
                        sum += (symbs[c] - 2 * symbs[prevChar]);
                    }
                    else
                    {
                        sum += symbs[c];
                    }
                    break;
                case 'C':
                    if (c == 'D' || c == 'M')
                    {
                        sum += (symbs[c] - 2 * symbs[prevChar]);
                    }
                    else
                    {
                        sum += symbs[c];
                    }
                    break;
                default:
                    sum += symbs[c];
                    break;
            }
            
            prevChar = c;
        }

        Console.WriteLine($"Арабское число: {sum}");
    }
}