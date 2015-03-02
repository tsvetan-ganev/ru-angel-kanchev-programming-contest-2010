using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology
{
	class Program
	{
		public static int SumDigits(string number)
		{
			int sum = 0;
			foreach (var digit in number)
			{
				sum += int.Parse(digit.ToString());
			}
			return sum;
		}

		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string date = Console.ReadLine();
				var numbers = date.Split('.');

				int sum = 0;
				foreach (var number in numbers)
				{
					sum += SumDigits(number);
				}

				while (sum.ToString().Length > 1)
				{
					sum = SumDigits(sum.ToString());
				}

				Console.WriteLine("{0} - {1}", date, sum);
			}
		}
	}
}
