using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> A = new List<int>();
			List<int> B = new List<int>();
			int iCnt = 1000000;
			A.Clear();
			B.Clear();
			for (int i = iCnt; i >=0; i--)
			{
				A.Add(i);
				B.Add(i * 2);
			}

			int lowerbound = 60, upperbond = 3000000;
			int count = GetCount(A, B, lowerbound, upperbond);
		}

		static int GetCount(List<int> A, List<int> B, int LowerBound, int UpperBound)
		{
			int rtn = 0;
			A.Sort();
			B.Sort();

			int iLforB = int.MaxValue;
			int iUforB = 0;
			for (int i=0;i<A.Count;i++)
			{
				int squareA = A[i] * A[i];
				if (UpperBound < squareA)
					break;

				if (iLforB >0)
				{
					if (LowerBound > squareA)
					{
						float fltLforB = (float)Math.Sqrt(LowerBound - A[i] * A[i]);
						iLforB = (int)Math.Ceiling(fltLforB);
					}
					else
						iLforB = 0;
				}

				float fltUforB = (float)Math.Sqrt(UpperBound - squareA);
				iUforB =(int)Math.Floor(fltUforB);

				rtn += (from num in B where num >= iLforB && num <= iUforB select num).Count();
			}
			return rtn;
		}
	}
}
