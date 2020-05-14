using MiNET.Worlds.Generator.Layers;

namespace MiNET.Worlds.Generator.Area
{
	public class LayerContext<A> : IContextExtended<A> where A : IArea
	{
		public ImprovedNoise noiseGenerator;
		private long PositionHash;
		private long Seed;
		public long SeedModifier;

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

		public A MakeArea(AreaDimension dimensionIn, IPixelTransformer transformer)
		{
		}

		public A MakeArea(AreaDimension dimensionIn, IPixelTransformer transformer, A p_201489_3_)
		{
			return MakeArea(dimensionIn, transformer);
		}

		public A MakeArea(
			AreaDimension dimensionIn,
			IPixelTransformer transformer,
			A p_201488_3_,
			A p_201488_4_)
		{
			return MakeArea(dimensionIn, transformer);
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
			if (i < 0) i += bound;

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
	}
}