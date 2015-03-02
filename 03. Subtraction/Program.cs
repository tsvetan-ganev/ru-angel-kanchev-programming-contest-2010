using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sub
{
	class Program
	{
		static string Subtract(StringBuilder larger, StringBuilder smaller)
		{
			if (larger.Equals(smaller))
			{
				return "0";
			}

			var result = new Stack<char>();

			// for each digit in the smaller number
			for (int i = 0; i < smaller.Length; i++)
			{
				int lastDigitLarger = int.Parse(
					larger[larger.Length - 1 - i].ToString());
				int lastDigitSmaller = int.Parse(
					smaller[smaller.Length - 1 - i].ToString());

				if (lastDigitSmaller > lastDigitLarger)
				{
					int j = 0;

					// while there are zeroes in the back of the larger number
					while (larger[larger.Length - 2 - i - j] == '0')
					{
						// make them 9s
						larger[larger.Length - 2 - i - j] = '9';
						j++;
					}

					// if any zeroes were converted to nines
					if (j != 0)
					{
						// decrement the first number, which preceedes the zero(es)
						var afterDecrementation = Char.Parse(
							(int.Parse(larger[larger.Length - 2 - i - j].ToString()) - 1)
							.ToString());
						larger[larger.Length - 2 - i - j] = afterDecrementation;
					}
					
					// increase the last digit by ten
					lastDigitLarger += 10;
					if (j == 0)
					{
						larger[larger.Length - 2 - i] = Char.Parse(
							(int.Parse(larger[larger.Length - 2 - i].ToString()) - 1)
							.ToString()); // previous digit
					}

				}

				char calculatedDigit = Char.Parse((lastDigitLarger - lastDigitSmaller).ToString());
				result.Push(calculatedDigit);
			}

			for (int i = larger.Length - smaller.Length - 1; i >= 0; i--)
			{
				result.Push(larger[i]);
			}

			var sb = new StringBuilder();
			while (result.Count != 0)
			{
				sb.Append(result.Pop());
			}

			// deleting leading zeroes
			while (sb.ToString().StartsWith("0"))
			{
				sb.Remove(0, 1);
			}

			return sb.ToString();
		}

		static StringBuilder SortByDescending(string number)
		{
			StringBuilder sb = new StringBuilder();
			var highest = number.OrderByDescending(c => c);
			foreach (var digit in highest)
			{
				sb.Append(digit);
			}

			// deleting leading zeroes
			while (sb.ToString().StartsWith("0"))
			{
				sb.Remove(0, 1);
			}

			return sb;
		}

		static StringBuilder SortByAscending(string number)
		{
			StringBuilder sb = new StringBuilder();
			var lowest = number.OrderBy(c => c);
			foreach (var digit in lowest)
			{
				sb.Append(digit);
			}

			// deleting leading zeroes
			while (sb.ToString().StartsWith("0"))
			{
				sb.Remove(0, 1);
			}

			return sb;
		}

		static void Main(string[] args)
		{
			string a = Console.ReadLine();
			var larger = SortByDescending(a);
			var smaller = SortByAscending(a);
			var result = Subtract(larger, smaller);

			Console.WriteLine(result);
		}
	}
}
