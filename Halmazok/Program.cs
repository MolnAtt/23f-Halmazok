using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Halmazok
{
	internal class Program
	{
		static List<int> ToHalmaz(List<int> l)
		{
			List<int> result = new List<int>();

			foreach (int elem in l)
			{
                if (!Bennevan(result,elem))
				{
					result.Add(elem);
				}
			}

			return result;
		}
		static bool Bennevan(List<int> l, int e)
		{
			int i = 0;
			while (i < l.Count && l[i]!=e)
			{
				i++;
			}
			return i < l.Count;
		}
		static string Stringbe<T>(List<T> t, string separator = " ", string start = "{ ", string end = " }")
		{
			if (t.Count == 0)
			{
				return start + end;
			}
			string result = start;
			for (int i = 0; i < t.Count - 1; i++)
			{
				result += $"{t[i]}" + separator;
			}
			result += $"{t[t.Count - 1]}";
			return result + end;
		}
		static string ToString(List<int> lista)
		{
			string result = "{ ";
			for (int i = 0; i < lista.Count - 1; i++)
			{
				result += lista[i].ToString() + "; ";
			}

			if (0 < lista.Count)
			{
				result += lista[lista.Count - 1].ToString();
			}

			return result += " }";
		}
		static List<int> Masol(List<int> l)
		{
			List<int> result = new List<int>();
			foreach (int e in l)
			{
				result.Add(e);
			}
			return result;
		}
		static List<int> Unio(List<int> a, List<int> b)
		{
			List<int> result = Masol(a);
			foreach (int item in b)
			{
				if (!Bennevan(result,item))
				{
					result.Add(item);
				}
			}
			return result;
		}
		static List<int> Metszet(List<int> a, List<int> b)
		{
			List<int> result = new List<int>();
			foreach (int item in a)
			{
				if (Bennevan(b, item))
				{
					result.Add(item);
				}
			}
			return result;
		}
		static List<int> Kivon(List<int> a, List<int> b)
		{
			List<int> result = new List<int>();
			foreach (int item in a)
			{
				if (!Bennevan(b, item))
				{
					result.Add(item);
				}
			}
			return result;
		}

		static void Kiir(List<int> l) => Console.WriteLine(Stringbe(l));

		static Random r = new Random();
		static List<int> Veletlenlista(int hossz, int min, int max)
		{
			List<int> result = new List<int>();
			for (int i = 0; i < hossz; i++)
			{
				result.Add(r.Next(min, max));
			}
			return result;
		}

		static void Main(string[] args)
		{
			List<int> a = ToHalmaz(Veletlenlista(20, 0, 10));
			List<int> b = ToHalmaz(Veletlenlista(20, -10, 10));
			Kiir(a);
			Kiir(b);
			Kiir(Unio(a, b));
			Kiir(Metszet(a, b));
			Kiir(Kivon(a, b));




		}
	}
}
