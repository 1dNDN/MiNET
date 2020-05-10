﻿using System;

namespace MiNET.Worlds.Generator
{
	class MathHelper
	{
		private static int[] MULTIPLY_DE_BRUIJN_BIT_POSITION =
		{
			0,
			1,
			28,
			2,
			29,
			14,
			24,
			3,
			30,
			22,
			20,
			15,
			25,
			17,
			4,
			8,
			31,
			27,
			13,
			23,
			21,
			19,
			16,
			7,
			26,
			12,
			18,
			6,
			11,
			5,
			10,
			9
		};

		public static double ClampedLerp(double lowerBnd, double upperBnd, double slide)
		{
			if (slide < 0.0D) return lowerBnd;

			return slide > 1.0D ? upperBnd : lowerBnd + (upperBnd - lowerBnd) * slide;
		}

		public static int SmallestEncompassingPowerOfTwo(int value)
		{
			int i = value - 1;
			i = i | i >> 1;
			i = i | i >> 2;
			i = i | i >> 4;
			i = i | i >> 8;
			i = i | i >> 16;

			return i + 1;
		}

		private static bool IsPowerOfTwo(int value)
		{
			return value != 0 && (value & value - 1) == 0;
		}

		public static int Log2DeBruijn(int value)
		{
			value = IsPowerOfTwo(value) ? value : SmallestEncompassingPowerOfTwo(value);

			return MULTIPLY_DE_BRUIJN_BIT_POSITION[(int) (value * 125613361L >> 27) & 31];
		}

		public static int Log2(int value)
		{
			return Log2DeBruijn(value) - (IsPowerOfTwo(value) ? 0 : 1);
		}

		public static int RoundUp(int number, int interval)
		{
			if (interval == 0) return 0;

			if (number == 0) return interval;
			if (number < 0) interval *= -1;

			int i = number % interval;

			return i == 0 ? number : number + interval - i;
		}

		public static void InclusiveBetween(long start, long end, long value)
		{
			if (value < start || value > end) throw new Exception();
		}
	}
}