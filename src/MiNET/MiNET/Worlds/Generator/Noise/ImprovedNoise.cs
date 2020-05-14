//2020 1dndn

namespace MiNET.Worlds.Generator
{
	public class ImprovedNoise
	{
		private static double[] GRAD_X =
		{
			1.0D,
			-1.0D,
			1.0D,
			-1.0D,
			1.0D,
			-1.0D,
			1.0D,
			-1.0D,
			0.0D,
			0.0D,
			0.0D,
			0.0D,
			1.0D,
			0.0D,
			-1.0D,
			0.0D
		};

		private static double[] GRAD_Y =
		{
			1.0D,
			1.0D,
			-1.0D,
			-1.0D,
			0.0D,
			0.0D,
			0.0D,
			0.0D,
			1.0D,
			-1.0D,
			1.0D,
			-1.0D,
			1.0D,
			-1.0D,
			1.0D,
			-1.0D
		};

		private static double[] GRAD_Z =
		{
			0.0D,
			0.0D,
			0.0D,
			0.0D,
			1.0D,
			1.0D,
			-1.0D,
			-1.0D,
			1.0D,
			1.0D,
			-1.0D,
			-1.0D,
			0.0D,
			1.0D,
			0.0D,
			-1.0D
		};

		private static double[] GRAD_2X =
		{
			1.0D,
			-1.0D,
			1.0D,
			-1.0D,
			1.0D,
			-1.0D,
			1.0D,
			-1.0D,
			0.0D,
			0.0D,
			0.0D,
			0.0D,
			1.0D,
			0.0D,
			-1.0D,
			0.0D
		};

		private static double[] GRAD_2Z =
		{
			0.0D,
			0.0D,
			0.0D,
			0.0D,
			1.0D,
			1.0D,
			-1.0D,
			-1.0D,
			1.0D,
			1.0D,
			-1.0D,
			-1.0D,
			0.0D,
			1.0D,
			0.0D,
			-1.0D
		};

		private int[] permutations = new int[512];
		public double xCoord;
		public double yCoord;
		public double zCoord;

		public ImprovedNoise(LongRandom seed)
		{
			xCoord = seed.NextDouble() * 256.0D;
			yCoord = seed.NextDouble() * 256.0D;
			zCoord = seed.NextDouble() * 256.0D;

			for (int i = 0; i < 256; permutations[i] = i++) ;

			for (int l = 0; l < 256; ++l)
			{
				int j = seed.NextInt(256 - l) + l;
				int k = permutations[l];
				permutations[l] = permutations[j];
				permutations[j] = k;
				permutations[l + 256] = permutations[l];
			}
		}

		public double GetValue(double x, double y, double z)
		{
			double d0 = x + xCoord;
			double d1 = y + yCoord;
			double d2 = z + zCoord;
			int i = (int) d0;
			int j = (int) d1;
			int k = (int) d2;
			if (d0 < i) --i;

			if (d1 < j) --j;

			if (d2 < k) --k;

			int l = i & 255;
			int i1 = j & 255;
			int j1 = k & 255;
			d0 = d0 - i;
			d1 = d1 - j;
			d2 = d2 - k;
			double d3 = d0 * d0 * d0 * (d0 * (d0 * 6.0D - 15.0D) + 10.0D);
			double d4 = d1 * d1 * d1 * (d1 * (d1 * 6.0D - 15.0D) + 10.0D);
			double d5 = d2 * d2 * d2 * (d2 * (d2 * 6.0D - 15.0D) + 10.0D);
			int k1 = permutations[l] + i1;
			int l1 = permutations[k1] + j1;
			int i2 = permutations[k1 + 1] + j1;
			int j2 = permutations[l + 1] + i1;
			int k2 = permutations[j2] + j1;
			int l2 = permutations[j2 + 1] + j1;

			return Lerp(
				d5,
				Lerp(
					d4,
					Lerp(
						d3,
						Grad(
							permutations[l1],
							d0,
							d1, d2),
						Grad(permutations[k2],
							d0 - 1.0D,
							d1, d2)),
					Lerp(
						d3,
						Grad(permutations[i2],
							d0,
							d1 - 1.0D,
							d2),
						Grad(permutations[l2],
							d0 - 1.0D,
							d1 - 1.0D,
							d2)
					)
				),
				Lerp(
					d4,
					Lerp(
						d3,
						Grad(
							permutations[l1 + 1],
							d0,
							d1,
							d2 - 1.0D),
						Grad(
							permutations[k2 + 1],
							d0 - 1.0D,
							d1,
							d2 - 1.0D)
					),
					Lerp(
						d3,
						Grad(
							permutations[i2 + 1],
							d0,
							d1 - 1.0D,
							d2 - 1.0D),
						Grad(
							permutations[l2 + 1],
							d0 - 1.0D,
							d1 - 1.0D,
							d2 - 1.0D)
					)
				)
			);
		}

		public double Lerp(double p_76311_1_, double p_76311_3_, double p_76311_5_)
		{
			return p_76311_3_ + p_76311_1_ * (p_76311_5_ - p_76311_3_);
		}

		public double Grad2(int p_76309_1_, double p_76309_2_, double p_76309_4_)
		{
			int i = p_76309_1_ & 15;

			return GRAD_2X[i] * p_76309_2_ + GRAD_2Z[i] * p_76309_4_;
		}

		public double Grad(
			int p_76310_1_,
			double p_76310_2_,
			double p_76310_4_,
			double p_76310_6_)
		{
			int i = p_76310_1_ & 15;

			return GRAD_X[i] * p_76310_2_ + GRAD_Y[i] * p_76310_4_ + GRAD_Z[i] * p_76310_6_;
		}

		public double func_205562_a(double x, double y) //2d
		{
			return GetValue(x, y, 0.0D);
		}

		public double func_205560_c(double x, double y, double z) //3d
		{
			return GetValue(x, y, z);
		}

		public void Add(
			double[] noiseArray,
			double xOffset,
			double yOffset,
			double zOffset,
			int xSize,
			int ySize,
			int zSize,
			double xScale,
			double yScale,
			double zScale,
			double noiseScale)
		{
			if (ySize == 1)
			{
				int i5 = 0;
				int j5 = 0;
				int j = 0;
				int k5 = 0;
				double d14 = 0.0D;
				double d15 = 0.0D;
				int l5 = 0;
				double d16 = 1.0D / noiseScale;

				for (int j2 = 0; j2 < xSize; ++j2)
				{
					double d17 = xOffset + j2 * xScale + xCoord;
					int i6 = (int) d17;
					if (d17 < i6) --i6;

					int k2 = i6 & 255;
					d17 = d17 - i6;
					double d18 = d17 * d17 * d17 * (d17 * (d17 * 6.0D - 15.0D) + 10.0D);

					for (int j6 = 0; j6 < zSize; ++j6)
					{
						double d19 = zOffset + j6 * zScale + zCoord;
						int k6 = (int) d19;
						if (d19 < k6) --k6;

						int l6 = k6 & 255;
						d19 = d19 - k6;
						double d20 = d19 * d19 * d19 * (d19 * (d19 * 6.0D - 15.0D) + 10.0D);
						i5 = permutations[k2] + 0;
						j5 = permutations[i5] + l6;
						j = permutations[k2 + 1] + 0;
						k5 = permutations[j] + l6;
						d14 = Lerp(d18, Grad2(permutations[j5], d17, d19), Grad(permutations[k5], d17 - 1.0D, 0.0D, d19));
						d15 = Lerp(d18, Grad(permutations[j5 + 1], d17, 0.0D, d19 - 1.0D), Grad(permutations[k5 + 1], d17 - 1.0D, 0.0D, d19 - 1.0D));
						double d21 = Lerp(d20, d14, d15);
						int i7 = l5++;
						noiseArray[i7] += d21 * d16;
					}
				}
			}
			else
			{
				int i = 0;
				double d0 = 1.0D / noiseScale;
				int k = -1;
				int l = 0;
				int i1 = 0;
				int j1 = 0;
				int k1 = 0;
				int l1 = 0;
				int i2 = 0;
				double d1 = 0.0D;
				double d2 = 0.0D;
				double d3 = 0.0D;
				double d4 = 0.0D;

				for (int l2 = 0; l2 < xSize; ++l2)
				{
					double d5 = xOffset + l2 * xScale + xCoord;
					int i3 = (int) d5;
					if (d5 < i3) --i3;

					int j3 = i3 & 255;
					d5 = d5 - i3;
					double d6 = d5 * d5 * d5 * (d5 * (d5 * 6.0D - 15.0D) + 10.0D);

					for (int k3 = 0; k3 < zSize; ++k3)
					{
						double d7 = zOffset + k3 * zScale + zCoord;
						int l3 = (int) d7;
						if (d7 < l3) --l3;

						int i4 = l3 & 255;
						d7 = d7 - l3;
						double d8 = d7 * d7 * d7 * (d7 * (d7 * 6.0D - 15.0D) + 10.0D);

						for (int j4 = 0; j4 < ySize; ++j4)
						{
							double d9 = yOffset + j4 * yScale + yCoord;
							int k4 = (int) d9;
							if (d9 < k4) --k4;

							int l4 = k4 & 255;
							d9 = d9 - k4;
							double d10 = d9 * d9 * d9 * (d9 * (d9 * 6.0D - 15.0D) + 10.0D);

							if (j4 == 0 || l4 != k)
							{
								k = l4;
								l = permutations[j3] + l4;
								i1 = permutations[l] + i4;
								j1 = permutations[l + 1] + i4;
								k1 = permutations[j3 + 1] + l4;
								l1 = permutations[k1] + i4;
								i2 = permutations[k1 + 1] + i4;
								d1 = Lerp(d6, Grad(permutations[i1], d5, d9, d7), Grad(permutations[l1], d5 - 1.0D, d9, d7));
								d2 = Lerp(d6, Grad(permutations[j1], d5, d9 - 1.0D, d7), Grad(permutations[i2], d5 - 1.0D, d9 - 1.0D, d7));
								d3 = Lerp(d6, Grad(permutations[i1 + 1], d5, d9, d7 - 1.0D), Grad(permutations[l1 + 1], d5 - 1.0D, d9, d7 - 1.0D));
								d4 = Lerp(d6, Grad(permutations[j1 + 1], d5, d9 - 1.0D, d7 - 1.0D), Grad(permutations[i2 + 1], d5 - 1.0D, d9 - 1.0D, d7 - 1.0D));
							}

							double d11 = Lerp(d10, d1, d2);
							double d12 = Lerp(d10, d3, d4);
							double d13 = Lerp(d8, d11, d12);
							int j7 = i++;
							noiseArray[j7] += d13 * d0;
						}
					}
				}
			}
		}
	}
}