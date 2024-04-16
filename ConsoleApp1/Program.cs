namespace ConsoleApp1;

public class Program
{
    static void Main(string[] args)
    {
        /* задание 1
        string J = Console.ReadLine();
        string S = Console.ReadLine();
        var jArr = J.ToCharArray();
        int jades = 0;
        
        foreach (var c in S)
        {
            if (jArr.Contains(c))
            {
                jades++;
            }
        }

        Console.WriteLine(jades);
        */
        
        /* задание 2
        int[] candidates = new int[] {10, 1, 2, 7, 6, 1, 5};
        int target = 8;
        List<string> variants = new List<string>();
        List<List<int>> correctVariants = new List<List<int>>();
        
        int maxVariants = (int)Math.Pow(2, candidates.Length);

        for (int i = 1; i < maxVariants; i++)
        {
            string binary = Convert.ToString(i, 2);
            binary = new string('0', candidates.Length - binary.Length) + binary;
            variants.Add(binary);
        }

        foreach (var variant in variants)
        {
            int sum = 0;

            var tempNums = new List<int>();
            
            for (int i = 0; i < variant.Length; i++)
            {
                if (variant[i] == '1')
                {
                    sum += candidates[i];
                    tempNums.Add(candidates[i]);
                }
            }

            if (sum == target)
            {
                var tempArr = tempNums.ToArray();
                Array.Sort(tempArr);
                correctVariants.Add(tempArr.ToList()); // добавлять надо если такого ещё нет (по идее)
            }
        }

        List<List<int>> uniqueCorrectVariants = new List<List<int>>();

        foreach (var v in correctVariants)
        {
            bool unique = true;
            foreach (var u in uniqueCorrectVariants)
            {
                if (u.SequenceEqual(v))
                {
                    unique = false;
                    break;
                }
            }

            if (unique)
            {
                uniqueCorrectVariants.Add(v);
            }
        }

        Console.WriteLine("Уникальные варианты:");
        foreach (var u in uniqueCorrectVariants)
        {
            foreach (var n in u)
            {
                Console.Write($"{n} ");
            }

            Console.WriteLine();
        }
        */

        /* задание 3
        //int[] nums = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
        int[] nums = new int[] { 1, 2, 3};
        var uniqueNums = nums.Distinct().ToArray();
        Console.WriteLine(nums.Length > uniqueNums.Length);
        */
    }
}