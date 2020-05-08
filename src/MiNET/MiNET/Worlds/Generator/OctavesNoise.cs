//2020 1dndn

using System;

namespace MiNET.Worlds.Generator
{
	internal class OctavesNoise
	{
		public ImprovedNoise[] GeneratorCollection;
		private int octaves;

		public OctavesNoise(LongRandom seed, int octavesIn)
		{
			octaves = octavesIn;
			GeneratorCollection = new ImprovedNoise[octavesIn];

			for (int i = 0; i < octavesIn; ++i) GeneratorCollection[i] = new ImprovedNoise(seed);
		}

		public double GetValue(double x, double y, double z)
		{
			double d0 = 0.0D;
			double d1 = 1.0D;

			for (int i = 0; i < octaves; ++i)
			{
				d0 += GeneratorCollection[i].func_205560_c(x * d1, y * d1, z * d1) / d1;
				d1 /= 2.0D;
			}

			return d0;
		}

		public double[] Add(
			int xOffset,
			int yOffset,
			int zOffset,
			int xSize,
			int ySize,
			int zSize,
			double xScale,
			double yScale,
			double zScale)
		{
			var adouble = new double[xSize * ySize * zSize];
			double d0 = 1.0D;

			for (int i = 0; i < octaves; ++i)
			{
				double d1 = xOffset * d0 * xScale;
				double d2 = yOffset * d0 * yScale;
				double d3 = zOffset * d0 * zScale;
				long j = (long)d1;
				long k = (long)d3;
				d1 = d1 - j;
				d3 = d3 - k;
				j = j % 16777216L;
				k = k % 16777216L;
				d1 = d1 + j;
				d3 = d3 + k;
				GeneratorCollection[i].Add(adouble, d1, d2, d3, xSize, ySize, zSize, xScale * d0, yScale * d0, zScale * d0, d0);
				d0 /= 2.0D;
			}

			return adouble;
		}

		public double[] Add(
			int xOffset,
			int zOffset,
			int xSize,
			int zSize,
			double xScale,
			double zScale,
			double exponentScale)
		{
			return Add(xOffset, 10, zOffset, xSize, 1, zSize, xScale, 1.0D, zScale);
		}
	}
}