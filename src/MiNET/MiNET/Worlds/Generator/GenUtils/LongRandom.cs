//2020 1dndn

using System;

namespace MiNET.Worlds.Generator
{
	public class LongRandom
	{
		private long _seed;
		private bool haveNextNextGaussian;
		private double nextNextGaussian;

		public LongRandom()
		{
		}

		/// <summary>
		/// </summary>
		/// <param name="seed"></param>
		public LongRandom(long seed)
		{
			SetSeed(seed);
		}

		/// <summary>
		///     Следующее случайное число
		/// </summary>
		/// <param name="bits">Количество случайных битов</param>
		/// <returns></returns>
		protected int Next(int bits)
		{
			_seed = (_seed * 0x5DEECE66DL + 0xBL) & ((1L << 48) - 1);

			return (int) ((uint) _seed >> (48 - bits)); //проверить, правильно ли работает
		}

		/// <summary>
		///     Изменяет sedd
		/// </summary>
		/// <param name="seed"></param>
		public void SetSeed(long seed)
		{
			_seed = (seed ^ 0x5DEECE66DL) & ((1L << 48) - 1);
			haveNextNextGaussian = false;
		}

		public bool NextBool()
		{
			return Next(1) != 0;
		}

		public void NextBytes(byte[] bytes)
		{
			for (int i = 0; i < bytes.Length;)
			for (int rnd = NextInt(), n = Math.Min(bytes.Length - i, 4);
				n-- > 0;
				rnd >>= 8)
				bytes[i++] = (byte) rnd;
		}

		public double NextDouble()
		{
			return (((long) Next(26) << 27) + Next(27)) / (double) (1L << 53);
		}

		public float NextFloat()
		{
			return Next(24) / (float) (1 << 24);
		}

		/// <summary>
		///     Возвращает распределенный по Гауссу double
		/// </summary>
		/// <returns></returns>
		public double NextGaussian()
		{
			if (haveNextNextGaussian)
			{
				haveNextNextGaussian = false;

				return nextNextGaussian;
			}

			double v1, v2, s;

			do
			{
				v1 = 2 * NextDouble() - 1; // between -1.0 and 1.0
				v2 = 2 * NextDouble() - 1; // between -1.0 and 1.0
				s = v1 * v1 + v2 * v2;
			} while (s >= 1 || s == 0);

			double multiplier = Math.Sqrt(-2 * Math.Log(s) / s);
			nextNextGaussian = v2 * multiplier;
			haveNextNextGaussian = true;

			return v1 * multiplier;
		}

		/// <summary>
		///     Возвращает случайный int
		/// </summary>
		/// <returns></returns>
		public int NextInt()
		{
			return Next(32);
		}

		/// <summary>
		///     Возвращает случайный int
		/// </summary>
		/// <param name="max">Верхняя граница</param>
		/// <returns></returns>
		public int NextInt(int max)
		{
			if (max <= 0) throw new ArgumentException("n must be positive");

			if ((max & -max) == max) // i.e., n is a power of 2
				return (int) ((max * (long) Next(31)) >> 31);

			int bits, val;

			do
			{
				bits = Next(31);
				val = bits % max;
			} while (bits - val + (max - 1) < 0);

			return val;
		}

		/// <summary>
		///     Возвращает случайный long
		/// </summary>
		/// <returns></returns>
		public long NextLong()
		{
			return ((long) Next(32) << 32) + Next(32);
		}
	}
}