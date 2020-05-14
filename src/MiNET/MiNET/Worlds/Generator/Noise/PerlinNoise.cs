//2020 1dndn

namespace MiNET.Worlds.Generator
{
	public class PerlinNoise
	{
		private int levels;
		private SimplexNoise[] noiseLevels;

		public PerlinNoise(LongRandom seed, int levelsIn)
		{
			levels = levelsIn;
			noiseLevels = new SimplexNoise[levelsIn];

			for (int i = 0; i < levelsIn; ++i) noiseLevels[i] = new SimplexNoise(seed);
		}

		public double GetValue(double x, double z)
		{
			double d0 = 0.0D;
			double d1 = 1.0D;

			for (int i = 0; i < levels; ++i)
			{
				d0 += noiseLevels[i].GetValue(x * d1, z * d1) / d1;
				d1 /= 2.0D;
			}

			return d0;
		}

		public double[] GenerateRegion(
			double startX,
			double startY,
			int xSize,
			int ySize,
			double xScale,
			double yScale,
			double p_202644_11_)
		{
			return GenerateRegion(startX, startY, xSize, ySize, xScale, yScale, p_202644_11_, 0.5D);
		}

		public double[] GenerateRegion(
			double startX,
			double startY,
			int xSize,
			int ySize,
			double xScale,
			double yScale,
			double p_202645_11_,
			double p_202645_13_)
		{
			var adouble = new double[xSize * ySize];
			double d0 = 1.0D;
			double d1 = 1.0D;

			for (int i = 0; i < levels; ++i)
			{
				noiseLevels[i].Add(adouble, startX, startY, xSize, ySize, xScale * d1 * d0, yScale * d1 * d0, 0.55D / d0);
				d1 *= p_202645_11_;
				d0 *= p_202645_13_;
			}

			return adouble;
		}
	}
}