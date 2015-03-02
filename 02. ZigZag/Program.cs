using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZag
{
	class Program
	{
		static void ZigZagFill(int[,] arr, int size)
		{
			int row = 0;
			int col = 0;
			int val = 1;
			int steps = 2 * size - 1;
			int currentStep = 0;
			int maxIndex = size - 1;
			int repetitionsCount = maxIndex;

			while (currentStep < steps)
			{
				if (currentStep <= steps / 2) // up to the diagonal
				{
					if (currentStep % 2 == 1)
					{
						row = 0;
						col = currentStep;

						for (int i = 0; i <= currentStep; i++)
						{
							arr[row, col] = val;
							row++;
							col--;
							val++;
						}
					}
					else if (currentStep % 2 == 0)
					{
						row = currentStep;
						col = 0;

						for (int i = 0; i <= currentStep; i++)
						{
							arr[row, col] = val;
							row--;
							col++;
							val++;
						}
					}
					currentStep++;
				}
				else if (currentStep > steps / 2) // down the diagonal
				{
					if (currentStep % 2 == 1)
					{
						row = currentStep - maxIndex;
						col = currentStep - row;

						for (int i = 0; i < repetitionsCount; i++)
						{
							arr[row, col] = val;
							row++;
							col--;
							val++;
						}
						repetitionsCount--;
					}
					else if (currentStep % 2 == 0)
					{
						col = currentStep - maxIndex;
						row = currentStep - col;

						for (int i = 0; i < repetitionsCount; i++)
						{
							arr[row, col] = val;
							row--;
							col++;
							val++;
						}
						repetitionsCount--;
					}
					currentStep++;
				}
			}
		}

		static string SearchArray(int[,] arr, int size, int value)
		{
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (arr[i, j] == value)
					{
						// in the desired answer format
						// the position starts from 1, not 0
						return String.Format("{0} {1}", i+1, j+1);
					}
				}
			}
			return String.Empty;
		}

		static void Main(string[] args)
		{
			var inputValues = Console.ReadLine().Split();
			int n = int.Parse(inputValues[0]);
			int numberToSearchFor = int.Parse(inputValues[1]);

			int[,] arr = new int[n, n];
			ZigZagFill(arr, n);

			string result = SearchArray(arr, n, numberToSearchFor);
			Console.WriteLine(result);
		}
	}
}
