using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			
			MySet ms1 = new MySet(new List<int>() { 1, 7, 3, 4 });
			
			Console.WriteLine(ms1);

			MySet ms2 = new MySet(new List<int>() { 2, 7, 3, 4 });

			Console.WriteLine(ms2);

			Console.WriteLine(ms1 > ms2);								//проверка на подмножество

			Console.WriteLine(ms1 % ms2);								//пересечение

			Console.WriteLine(ms1 ^ ms2);								//проверка на неравенство

			Console.WriteLine(ms1 - 2);									//удаление

			Console.WriteLine(ms1 << 9);								//добавление

			WordPoint.ShortString("Мы учимся программировать" +
   " на многочисленных языках программрования!");						//Поиск самого короткого слова

			WordPoint.Sets(ms1.Set);									//упорядочивание множества


			Console.ReadKey();
		}
	}

	class MySet
	{
		public List<int> Set { get; set; }

		public MySet()
		{
			Set = new List<int>();
		}
		public MySet(List<int> set)
		{
			Set = set;
		}
		//Пересечение множеств
		public static MySet operator %(MySet mas1, MySet mas2)
		{
			List<int> resultList = mas1.Set.Intersect(mas2.Set).ToList();
			MySet resultSet = new MySet();
			resultSet.Set = resultList;
			return resultSet;
		}
		//Добавить элемент во множество
		public static MySet operator <<(MySet mas1, int x)
		{
			mas1.Set.Add(x);
			MySet result = new MySet();
			result.Set = mas1.Set;
			return result;

		}
		//Сравнение множеств
		public static bool operator <(MySet mas1, MySet mas2)
		{
			mas1.Set.Sort();
			mas2.Set.Sort();
			bool x = false;
			foreach (int value in mas1.Set)
			{
				foreach (int value1 in mas2.Set)
				{
					if (value == value1)
					{
						x = true;
					}
					else
					{
						x = false;
						break;
					}
					break;
				}
				break;
			}
			return x;
		}
		//Проверка на неравенство
		public static bool operator ^(MySet mas1, MySet mas2)
		{
			mas1.Set.Sort();
			mas2.Set.Sort();
			bool x = false;
			foreach (int value in mas1.Set)
			{
				foreach (int value1 in mas2.Set)
				{
					if (value != value1)
					{
						x = true;
					}
					else
					{
						x = false;
						break;
					}
					break;
				}
				break;
			}
			return x;
		}
		//Удалить элемент из множества
		public static MySet operator -(MySet mas1, int x)
		{
			mas1.Set.Remove(x);
			MySet result = new MySet();
			result.Set = mas1.Set;
			return result;
		}
		//Проверка на подмножество
		public static bool operator >(MySet mas1, MySet mas2)
		{

			// Проверяем входные данные на пустоту.
			if (mas1 == null)
			{
				throw new ArgumentNullException(nameof(mas1));
			}

			if (mas2 == null)
			{
				throw new ArgumentNullException(nameof(mas2));
			}

			var result = mas1.Set.All(s => mas2.Set.Contains(s));
			return result;			
		}		

		//Переопределяем методы
		public override string ToString()
		{
			string s = "";
			foreach (int? val in Set)
			{
				if (val == null)
				{ 
					continue;
				}
				else
				{ 
					s += val + "; ";
				}
			}
			return s;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}
	}
	//Методы расширения
	public static class WordPoint
	{
		//Поиск самого короткого слова
		public static void ShortString(this string s1)
		{
			int minInd = 0;
			string[] dd = s1.Split(' ');
			int min = dd[0].Length;

			for (int i = 0; i < dd.Length; i++)
				if (min > dd[i].Length) { min = dd[i].Length; minInd = i; }

			Console.WriteLine("самое кроткое слово: {0} ", dd[minInd]);
			Console.WriteLine("индекс самого кроткого слова: {0} ", minInd);
			Console.WriteLine(s1);
			
		}
		//Упорядочивание списка
		public static void Sets(this List<int> list)
		{
			list.Sort();
			foreach (object i in list)
				Console.Write(i + "; ");
		}
	}
}
