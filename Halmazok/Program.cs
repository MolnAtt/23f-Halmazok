using System;
using System.CodeDom;
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

		class Halmaz<T>
		{
			public List<T> l;

			public Halmaz()
			{
				this.l = new List<T>();
			}

			public Halmaz(List<T> lista)
			{
				this.l = new List<T>();

				foreach (T elem in lista)
				{
					if (!Bennevan(l, elem))
					{
						l.Add(elem);
					}
				}
			}

			public bool Tartalmazza(T e)
			{
				int i = 0;
				while (i < this.l.Count && !this.l[i].Equals(e))
				{
					i++;
				}
				return i < this.l.Count;
			}

			public override string ToString()
			{
				return Stringbe(this.l, "; ", "{ ", " }");
			}

			public Halmaz<T> Masolat()
			{
				Halmaz<T> result = new Halmaz<T>();
				foreach (T e in this.l)
				{
					result.l.Add(e);
				}
				return result;
			}

			public static Halmaz<T> operator +(Halmaz<T> a, Halmaz<T> b)
			{
				Halmaz<T> result = a.Masolat();
				foreach (T item in b.l)
				{
					if (!result.Tartalmazza(item))
					{
						result.l.Add(item);
					}
				}
				return result;
			}
			public static Halmaz<T> operator *(Halmaz<T> a, Halmaz<T> b)
			{
				Halmaz<T> result = new Halmaz<T>();
				foreach (T item in a.l)
				{
					if (b.Tartalmazza(item))
					{
						result.l.Add(item);
					}
				}
				return result;
			}
			public static Halmaz<T> operator -(Halmaz<T> a, Halmaz<T> b)
			{
				Halmaz<T> result = new Halmaz<T>();
				foreach (T item in a.l)
				{
					if (!b.Tartalmazza(item))
					{
						result.l.Add(item);
					}
				}
				return result;
			}

			public static bool operator <=(Halmaz<T> a, Halmaz<T> b)
			{
				foreach (T a_eleme in a.l)
					if (!b.Tartalmazza(a_eleme))
						return false;
				return true;
			}

			public static bool operator >=(Halmaz<T> a, Halmaz<T> b) => b <= a;
			//public static bool operator >=(Halmaz a, Halmaz b) 
			//{
			//	return b <= a;
			//}

			public static bool operator ==(Halmaz<T> a, Halmaz<T> b) => a.l.Count == b.l.Count && a <= b;
			public static bool operator <(Halmaz<T> a, Halmaz<T> b) => a.l.Count < b.l.Count && a <= b;
			public static bool operator >(Halmaz<T> a, Halmaz<T> b) => b < a;
			public static bool operator !=(Halmaz<T> a, Halmaz<T> b) => !(a == b);

		}



		static bool Bennevan<T>(List<T> l, T e)
		{
			int i = 0;
			while (i < l.Count && !l[i].Equals(e))
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

		static bool Részhalmaz(List<int> a, List<int> b)
		{
			// keressük az első olyan elemét a-nak, ami nincs benne b-ben.

			int i = 0;
			while (i<a.Count && Bennevan(b, a[i]))
				i++;

			return i >= a.Count;
		}


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
			Halmaz<int> h = new Halmaz<int>(new List<int> { 1, 2, 5, 6, 9 });
			Halmaz<int> g = new Halmaz<int>(new List<int> { 6, 2, 9 });
			Console.WriteLine(h);
			Console.WriteLine(g);
            Console.WriteLine(h + g);
			Console.WriteLine(h * g);
			Console.WriteLine(h - g);
			Console.WriteLine(g < h);
			Console.WriteLine(g <= h);
		}
	}
}
