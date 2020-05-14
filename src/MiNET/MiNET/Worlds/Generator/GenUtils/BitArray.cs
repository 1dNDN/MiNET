using System;

namespace MiNET.Worlds.Generator
{
	class BitArray
	{
		private int ArraySize;
		private int BitsPerEntry;
		private long[] LongArray;
		private long MaxEntryValue;

		public BitArray(int bitsPerEntry, int arraySize) : this(bitsPerEntry, arraySize, new long[MathHelper.RoundUp(arraySize * bitsPerEntry, 64) / 64]) { }

		public BitArray(int bitsPerEntry, int arraySize, long[] array)
		{
			MathHelper.InclusiveBetween(1L, 32L, bitsPerEntry);
			ArraySize = arraySize;
			BitsPerEntry = bitsPerEntry;
			LongArray = array;
			MaxEntryValue = (1L << bitsPerEntry) - 1L;
			int i = MathHelper.RoundUp(arraySize * bitsPerEntry, 64) / 64;

			if (array.Length != i) throw new ArgumentOutOfRangeException();
		}

		public void SetAt(int index, int value)
		{
			MathHelper.InclusiveBetween(0L, ArraySize - 1, index);
			MathHelper.InclusiveBetween(0L, MaxEntryValue, value);
			int i = index * BitsPerEntry;
			int j = i / 64;
			int k = ((index + 1) * BitsPerEntry - 1) / 64;
			int l = i % 64;
			LongArray[j] = LongArray[j] & ~(MaxEntryValue << l) | (value & MaxEntryValue) << l;

			if (j != k)
			{
				int i1 = 64 - l;
				int j1 = BitsPerEntry - i1;
				LongArray[k] = Math.Abs(LongArray[k]) >> j1 << j1 | (value & MaxEntryValue) >> i1;
			}
		}

		public int GetAt(int index)
		{
			MathHelper.InclusiveBetween(0L, ArraySize - 1, index);
			int i = index * BitsPerEntry;
			int j = i / 64;
			int k = ((index + 1) * BitsPerEntry - 1) / 64;
			int l = i % 64;

			if (j == k) return (int) (Math.Abs(LongArray[j]) >> l & MaxEntryValue);
			int i1 = 64 - l;

			return (int) ((Math.Abs(LongArray[j]) >> l | LongArray[k] << i1) & MaxEntryValue);
		}

		public long[] GetBackingLongArray()
		{
			return LongArray;
		}

		public int Size()
		{
			return ArraySize;
		}

		public int GetBitsPerEntry()
		{
			return BitsPerEntry;
		}
	}
}