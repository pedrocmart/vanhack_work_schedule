using System;
using System.Collections.Generic;
using System.Linq;

public class Result
{

    public static int sumOfDigits(string s)
    {
        int sum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            sum += (int)(c - '0');
        }
        return sum;
    }

    public static List<string> findSchedules(int workHours, int dayHours, string pattern)
    {

        List<string> x = new List<string>();
        if (pattern.IndexOf('?') != -1)
        {
            int index = pattern.IndexOf("?");
            string first = pattern.Substring(0, index);
            string last = pattern.Substring(index + 1);

            for (int i = 0; i <= dayHours; i++)
            {
                List<string> result = findSchedules(workHours, dayHours, first + Convert.ToString(i) + last);

                x.AddRange(result);
            }
        }
        else
        {
            if (sumOfDigits(pattern) == workHours)
            {
                x.Add(pattern);
            }
        }
        return x;
    }


    public class Work
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int workHours = Convert.ToInt32(Console.ReadLine().Trim());

            int dayHours = Convert.ToInt32(Console.ReadLine().Trim());

            string pattern = Console.ReadLine();

            List<string> result = Result.findSchedules(workHours, dayHours, pattern);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            //textWriter.WriteLine(String.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
