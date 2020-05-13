namespace MiNET.Worlds.Generator.Area
{
	class LayerContext
	{
		private long Seed;
		private long PositionHash;
		protected long SeedModifier;
		protected ImprovedNoise noiseGenerator;

		public LayerContext(long seedModifier)
		{
			SeedModifier = seedModifier;
			SeedModifier *= SeedModifier * 6364136223846793005L + 1442695040888963407L;
			SeedModifier += seedModifier;
			SeedModifier *= SeedModifier * 6364136223846793005L + 1442695040888963407L;
			SeedModifier += seedModifier;
			SeedModifier *= SeedModifier * 6364136223846793005L + 1442695040888963407L;
			SeedModifier += seedModifier;
		}

		public void SetSeed(long seed)
		{
			Seed = seed;
			Seed *= Seed * 6364136223846793005L + 1442695040888963407L;
			Seed += SeedModifier;
			Seed *= Seed * 6364136223846793005L + 1442695040888963407L;
			Seed += SeedModifier;
			Seed *= Seed * 6364136223846793005L + 1442695040888963407L;
			Seed += SeedModifier;
			noiseGenerator = new ImprovedNoise(new LongRandom(seed));
		}

		public void SetPosition(long x, long z)
		{
			PositionHash = Seed;
			PositionHash *= PositionHash * 6364136223846793005L + 1442695040888963407L;
			PositionHash += x;
			PositionHash *= PositionHash * 6364136223846793005L + 1442695040888963407L;
			PositionHash += z;
			PositionHash *= PositionHash * 6364136223846793005L + 1442695040888963407L;
			PositionHash += x;
			PositionHash *= PositionHash * 6364136223846793005L + 1442695040888963407L;
			PositionHash += z;
		}

		public int Random(int bound)
		{
			int i = (int) ((PositionHash >> 24) % bound);
			if (i < 0)
			{
				i += bound;
			}

			PositionHash *= PositionHash * 6364136223846793005L + 1442695040888963407L;
			PositionHash += Seed;
			return i;
		}

		public int SelectRandomly(int[] choices)
		{
			return choices[Random(choices.Length)];
		}

		public ImprovedNoise GetNoiseGenerator()
		{
			return noiseGenerator;
		}
	}
}
