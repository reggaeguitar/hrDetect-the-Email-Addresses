namespace hrDetect_the_Email_Addresses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var regex = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.Compiled);
            var numLines = Int32.Parse(Console.ReadLine());
            var answers = new HashSet<string>();
            while (numLines-- > 0)
            {
                var line = Console.ReadLine();
                foreach (var match in regex.Matches(line).Cast<Match>().Where(x => x.Success))
                {
                    answers.Add(match.Value);
                }
            }
            var sb = new StringBuilder();
            foreach (var answer in answers.OrderBy(x => x, StringComparer.Ordinal))
            {
                sb.Append(answer);
                sb.Append(';');
            }
            Console.WriteLine(sb.ToString().Trim(';'));
            Console.ReadLine();
        }
    }
}
