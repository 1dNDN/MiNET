namespace MiNET.Worlds.Generator
{
	class SharedSeedRandom:LongRandom
	{
		private int UsageCount;

		public SharedSeedRandom()
		{
		}

		public SharedSeedRandom(long seed) : base(seed)
		{
		}

		public void Skip(int bits)
		{
			for (int i = 0; i < bits; ++i)
			{
				Next(1);
			}

		}

		protected new int Next(int bits)
		{
			++UsageCount;
			return base.Next(bits);
		}

		public long SetBaseChunkSeed(int x, int z)
		{
			long i = x * 341873128712L + z * 132897987541L; 
			SetSeed(i);
			return i;
		}

		public long SetDecorationSeed(long baseSeed, int x, int z)
		{
			SetSeed(baseSeed);
			long i = NextLong() | 1L;
			long j = NextLong() | 1L;
			long k = x * i + z * j ^ baseSeed;
			SetSeed(k);
			return k;
		}

		public long SetFeatureSeed(long baseSeed, int x, int z)
		{
			long i = baseSeed + x + 10000 * z;
			SetSeed(i);
			return i;
		}

		public long SetLargeFeatureSeed(long seed, int x, int z)
		{
			SetSeed(seed);
			long i = NextLong();
			long j = NextLong();
			long k = x * i ^ z * j ^ seed;
			SetSeed(k);
			return k;
		}

		public long SetLargeFeatureSeedWithSalt(long baseSeed, int x, int z, int modifier)
		{
			long i = x * 341873128712L + z * 132897987541L + baseSeed + modifier;
			SetSeed(i);
			return i;
		}

		public static LongRandom SeedSlimeChunk(int p_205190_0_, int p_205190_1_, long p_205190_2_, long p_205190_4_)
		{
			return new LongRandom(p_205190_2_ + p_205190_0_ * p_205190_0_ * 4987142 + p_205190_0_ * 5947611 + p_205190_1_ * p_205190_1_ * 4392871L + p_205190_1_ * 389711 ^ p_205190_4_);
		}
	}
}
